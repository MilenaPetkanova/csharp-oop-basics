using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager 
{
    private string currentMode;
    private double totalStoredEnergy;
    private double totalMinedOre;

    private ICollection<Provider> allProviders;
    private ICollection<Harvester> allHarvesters;
    private HarvesterFactory harvesterFactory;
    private ProviderFactory providerFactory;

    public DraftManager()
    {
        this.allProviders = new List<Provider>();
        this.allHarvesters = new List<Harvester>();
        this.providerFactory = new ProviderFactory();
        this.harvesterFactory = new HarvesterFactory();
        this.currentMode = "Full";
        this.totalMinedOre = 0;
        this.totalStoredEnergy = 0;
    }
    
    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            var harvester = harvesterFactory.CreateHarvester(arguments);
            allHarvesters.Add(harvester);
            return $"Successfully registered {harvester.Type} Harvester - {harvester.Id}";
        }
        catch (ArgumentException ex)
        {
            return ex.Message;
        }
    }

    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            var provider = providerFactory.CreateProvider(arguments);
            allProviders.Add(provider);
            return $"Successfully registered {provider.Type} Provider - {provider.Id}";
        }
        catch (ArgumentException ex)
        {
            return ex.Message;
        }
    }

    public string Day()
    {
        var energyRequiredPerDay = 0d;
        var oreMinedPerDay = 0d;

        var energyProvidedPerDay = allProviders.Sum(p => p.EnergyOutput);

        if (this.currentMode == "Full")
        {
            energyRequiredPerDay = allHarvesters.Sum(h => h.EnergyRequirement);
            oreMinedPerDay = allHarvesters.Sum(h => h.OreOutput);
        }
        else if (this.currentMode == "Half")
        {
            energyRequiredPerDay = allHarvesters.Sum(h => h.EnergyRequirement) * 0.6;
            oreMinedPerDay = allHarvesters.Sum(h => h.OreOutput) * 0.5;
        }
        else if (this.currentMode == "Energy")
        {
            energyRequiredPerDay = 0;
            oreMinedPerDay = 0;
        }

        this.totalStoredEnergy += energyProvidedPerDay;
        if (this.totalStoredEnergy >= energyRequiredPerDay)
        {
            this.totalMinedOre += oreMinedPerDay;
            this.totalStoredEnergy -= energyRequiredPerDay;
        }
        else
        {
            oreMinedPerDay = 0;
        }

        return $"A day has passed." + Environment.NewLine +
            $"Energy Provided: {energyProvidedPerDay}" + Environment.NewLine +
            $"Plumbus Ore Mined: {oreMinedPerDay}";
        }

    public string Mode(List<string> arguments)
    {
        this.currentMode = arguments[0];
        return $"Successfully changed working mode to {this.currentMode} Mode";
    }

    public string Check(List<string> arguments)
    {
        var output = string.Empty;
        string id = arguments[0];

        Unit unit = (Unit)this.allProviders.FirstOrDefault(p => p.Id == id) 
                    ?? this.allHarvesters.FirstOrDefault(h => h.Id == id);

        if (unit != null)
        {
            return unit.ToString();
        }
        else
        {
            return $"No element found with id - {id}";
        }
    }
    
    public string ShutDown()
    {
        if (this.totalStoredEnergy < 0)
        {
            this.totalStoredEnergy = 0;
        }
        else if (this.totalMinedOre < 0)
        {
            this.totalMinedOre = 0;
        }

        var output = new StringBuilder();
        output.AppendLine("System Shutdown");
        output.AppendLine($"Total Energy Stored: {this.totalStoredEnergy}");
        output.Append($"Total Mined Plumbus Ore: {this.totalMinedOre}");

        return output.ToString();
    }
}
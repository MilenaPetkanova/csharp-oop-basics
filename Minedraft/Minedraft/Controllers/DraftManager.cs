using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager : IDraftManagable
{
    private string currentMode;
    private double totalStoredEnergy;
    private double totalMinedOre;

    public DraftManager()
    {
        this.AllProviders = new List<Provider>();
        this.AllHarvesters = new List<Harvester>();
        this.CurrentMode = "Full";
    }

    public ICollection<Provider> AllProviders { get; private set; }

    public ICollection<Harvester> AllHarvesters { get; private set; }

    public string CurrentMode { get; private set; }

    public double TotalStoredEnergy { get; private set; }

    public double TotalMinedOre { get; private set; }


    public string Check(List<string> arguments)
    {
        var output = string.Empty;
        string id = arguments[0];

        var choosenProvider = this.AllProviders.FirstOrDefault(p => p.Id == id);
        var choosenHarveser = this.AllHarvesters.FirstOrDefault(h => h.Id == id);

        if (choosenProvider == null && choosenHarveser == null)
        {
            throw new ArgumentException($"No element found with id - {id}");
        }

        else if (choosenProvider != null)
        {
            output = choosenProvider.ToString();
        }

        else if (choosenHarveser != null)
        {
            output = choosenHarveser.ToString();
        }

        return output;
    }

    public string Day()
    {
        var energyProvided = 0d;
        var energyRequirements = CalculateEnergyRequirements();
        var oreMined = 0d;

        foreach (var provider in this.AllProviders)
        {
            energyProvided += provider.ProduceEnergy();
        }

        this.totalStoredEnergy += energyProvided;

        if (this.totalStoredEnergy >= energyRequirements)
        {
            oreMined = CalculateOreMined();

            this.totalStoredEnergy -= energyRequirements;
            this.totalMinedOre += oreMined;
        }

        var output = new StringBuilder();
        output.AppendLine("A day has passed.");
        output.AppendLine($"Energy Provided: {energyProvided}");
        output.Append($"Plumbus Ore Mined: {oreMined}");

        return output.ToString();
    }

    public string Mode(List<string> arguments)
    {
        if (arguments[0].Equals("Full") || arguments[0].Equals("Half") || arguments[0].Equals("Energy"))
        {
            this.currentMode = arguments[0];
        }

        var output = $"Successfully changed working mode to {this.currentMode} Mode";
        return output;
    }

    public string RegisterHarvester(List<string> arguments)
    {
        var type = arguments[0];
        var id = arguments[1];
        var oreOutput = double.Parse(arguments[2]);
        var energyRequirement = double.Parse(arguments[3]);

        try
        {
            if (type.Equals("Sonic"))
            {
                int sonicFactor = int.Parse(arguments[4]);
                this.AllHarvesters.Add(new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor));
            }
            else if (type.Equals("Hammer"))
            {
                this.AllHarvesters.Add(new HammerHarvester(id, oreOutput, energyRequirement));
            }

            var output = $"Successfully registered {type} Harvester - {id}";
            return output;
        }
        catch (ArgumentException ex)
        {
            return ex.Message;
        }
    }

    public string RegisterProvider(List<string> arguments)
    {
        var type = arguments[0];
        var id = arguments[1];
        var energyOutput = double.Parse(arguments[2]);

        try
        {
            if (type.Equals("Solar"))
            {
                this.AllProviders.Add(new SolarProvider(id, energyOutput));
            }
            else if (type.Equals("Pressure"))
            { 
                this.AllProviders.Add(new PressureProvider(id, energyOutput));
            }

            var output = $"Successfully registered {type} Provider - {id}";
            return output;
        }
        catch (ArgumentException ex)
        {
            return ex.Message;
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

    private double CalculateEnergyRequirements()
    {
        var energyRequirements = 0d;
        if (this.CurrentMode == "Full")
        {
            energyRequirements = this.AllHarvesters.Sum(x => x.EnergyRequirement);
        }
        else if (this.CurrentMode == "Half")
        {
            energyRequirements = 0.6 * this.AllHarvesters.Sum(x => x.EnergyRequirement);
        }
        return energyRequirements;
    }

    private double CalculateOreMined()
    {
        var oreMined = 0d;
        var coef = 0d;

        if (this.CurrentMode == "Full")
        {
            coef = 1;
        }
        else if (this.CurrentMode == "Half")
        {
            coef = 0.5;
        }
        else if (this.CurrentMode == "Energy")
        {
            coef = 0;
        }

        foreach (var harvester in AllHarvesters)
        {
            oreMined += harvester.MinePlumbusOre(coef);
        }

        return oreMined;
    }
}
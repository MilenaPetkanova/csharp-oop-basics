using System.Text;

public class SonicHarvester : Harvester
{
    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor)
        : base(id, oreOutput, energyRequirement)
    {
        this.SonicFactor = sonicFactor;
        base.EnergyRequirement /= this.SonicFactor;
    }

    public int SonicFactor { get; private set; }

    public override string ToString()
    {
        var output = new StringBuilder();
        output.AppendLine($"Sonic Harvester - {this.Id}");
        output.AppendLine($"Ore Output: {base.OreOutput}");
        output.Append($"Energy Requirement: {base.EnergyRequirement}");

        return output.ToString();
    }
}

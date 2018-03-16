using System.Text;

public class HammerHarvester : Harvester
{
    public HammerHarvester(string id, double oreOutput, double energyRequirement)
        : base(id, oreOutput, energyRequirement)
    {
        base.OreOutput *= 3;
        base.EnergyRequirement *= 2;
    }

    public override string Type => "Hammer";

    public override string ToString()
    {
        var output = new StringBuilder();
        output.AppendLine($"Hammer Harvester - {this.Id}");
        output.AppendLine($"Ore Output: {base.OreOutput}");
        output.Append($"Energy Requirement: {base.EnergyRequirement}");

        return output.ToString();
    }
}

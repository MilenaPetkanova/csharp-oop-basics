using System.Text;

public class SolarProvider : Provider
{
    public SolarProvider(string id, double energyOutput)
        : base(id, energyOutput)
    {
    }

    public override string ToString()
    {
        var output = new StringBuilder();
        output.AppendLine($"Solar Provider - {this.Id}");
        output.Append($"Energy Output: {base.EnergyOutput}");

        return output.ToString();
    }
}
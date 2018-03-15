using System.Text;

public class PressureProvider : Provider
{
    public PressureProvider(string id, double energyOutput)
        : base(id, energyOutput)
    {
        base.EnergyOutput *= 1.5;
    }

    public override string ToString()
    {
        var output = new StringBuilder();
        output.AppendLine($"Pressure Provider - {this.Id}");
        output.Append($"Energy Output: {base.EnergyOutput}");

        return output.ToString();
    }
}
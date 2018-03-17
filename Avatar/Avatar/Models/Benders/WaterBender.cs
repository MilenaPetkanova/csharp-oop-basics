public class WaterBender : Bender
{
    public WaterBender(string name, int power, double waterClarity) 
        : base(name, power)
    {
        this.WaterClarity = waterClarity;
    }

    public double WaterClarity { get; private set; }

    public double CalculatePower()
    {
        return base.Power * this.WaterClarity;
    }

    public override string ToString()
    {
        return "Water Bender: " + base.ToString() + $"Water Clarity: {this.WaterClarity:f2}";
    }
}


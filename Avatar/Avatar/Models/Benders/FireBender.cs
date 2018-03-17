public class FireBender : Bender
{
    public FireBender(string name, int power, double heatAggression) 
        : base(name, power)
    {
        this.HeatAggression = heatAggression;
    }

    public double HeatAggression { get; private set; }

    public double CalculatePower()
    {
        return base.Power * this.HeatAggression;
    }

    public override string ToString()
    {
        return "Fire Bender: " + base.ToString() + $"Heat Aggression: {this.HeatAggression:f2}";
    }
}


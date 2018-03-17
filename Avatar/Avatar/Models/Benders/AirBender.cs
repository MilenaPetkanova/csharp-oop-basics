public class AirBender : Bender
{
    public AirBender(string name, int power, double aerialIntegrity) 
        : base(name, power)
    {
        this.AerialIntegrity = aerialIntegrity;
    }

    public double AerialIntegrity { get; private set; }

    public double CalculatePower()
    {
        return base.Power * this.AerialIntegrity;
    }

    public override string ToString()
    {
        return "Air Bender: " + base.ToString() + $"Aerial Integrity: {this.AerialIntegrity:f2}";
    }
}


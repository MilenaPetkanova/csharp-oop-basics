public class EarthBender : Bender
{
    public EarthBender(string name, int power, double groundSaturation) 
        : base(name, power)
    {
        this.GroundSaturation = groundSaturation;
    }

    public double GroundSaturation { get; private set; }

    public double CalculatePower()
    {
        return base.Power * this.GroundSaturation;
    }

    public override string ToString()
    {
        return "Earth Bender: " + base.ToString() + $"Ground Satiration: {this.GroundSaturation:f2}";
    }
}


public class AirMonument : Monument
{
    private int airAffinity;

    public AirMonument(string name, int airAffinity) 
        : base(name)
    {
        this.AirAffinity = airAffinity;
        base.Affinity = airAffinity;
    }

    public int AirAffinity
    {
        get { return airAffinity; }
        set { airAffinity = value; }
    }

    public override string ToString()
    {
        return "Air " + base.ToString() + $"Air Affinity: {this.airAffinity:f2}";
    }
}

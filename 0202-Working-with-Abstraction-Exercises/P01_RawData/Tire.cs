using System.Collections.Generic;

public class Tire
{
    private KeyValuePair<double, int> tireParams;

    public KeyValuePair<double, int> TireParams { get; set; }

    public Tire(double tirePressure, int tireAge)
    {
        this.TireParams = new KeyValuePair<double, int>(tirePressure, tireAge);
    }
    
    public bool IsFragile()
    {
        return this.TireParams.Key < 1;
    }
} 
public class AggressiveDriver : Driver
{
    public AggressiveDriver(string name, Car car)
       : base(name, car)
    {
        base.FuelConsumptionPerKm = 2.7;
        base.Speed *= 1.3;
    }
}


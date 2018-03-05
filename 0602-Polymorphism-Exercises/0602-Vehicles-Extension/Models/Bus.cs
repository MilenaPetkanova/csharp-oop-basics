public class Bus : Vehicle
{
    public Bus(double fuelQuantity, double litersPerKm, double tankCapacity)
        : base(fuelQuantity, litersPerKm, tankCapacity)
    {
    }

    public override string Drive(double distance)
    {
        var fuelNeeded = distance * (this.LitersPerKm + 1.4);

        if (base.FuelQuantity - fuelNeeded < 0)
        {
            return $"{this.GetType()} needs refueling";
        }
        else
        {
            base.FuelQuantity -= fuelNeeded;
            return $"{this.GetType()} travelled {distance} km";
        }
    }

    public string DriveEmpty(double distance)
    {
        return base.Drive(distance);
    } 
}
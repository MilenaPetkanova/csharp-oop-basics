public abstract class Vehicle : IVehicle
{
    public Vehicle(double fuelQuantity, double litersPerKm)
    {
        this.FuelQuantity = fuelQuantity;
        this.LitersPerKm = litersPerKm;
    }

    public virtual double FuelQuantity { get; protected set; }

    public virtual double LitersPerKm { get; private set; }

    public virtual string Drive(double distance)
    {
        double fuelNeeded = distance * this.LitersPerKm;

        if (this.FuelQuantity - fuelNeeded < 0)
        {
            return $"{this.GetType()} needs refueling";
        }
        else
        {
            this.FuelQuantity -= fuelNeeded;
            return $"{this.GetType()} travelled {distance} km";
        }
    }

    public virtual void Refuel(double quantity)
    {
        this.FuelQuantity += quantity;
    }

    public override string ToString()
    {
        return $"{this.GetType()}: {this.FuelQuantity:F2}";
    }
}
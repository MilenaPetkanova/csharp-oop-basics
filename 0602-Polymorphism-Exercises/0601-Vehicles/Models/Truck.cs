public class Truck : Vehicle
{
    public Truck(double fuelQuantity, double litersPerKm)
        : base(fuelQuantity, litersPerKm)
    {
    }

    public override double LitersPerKm => base.LitersPerKm + 1.6;

    public override void Refuel(double quantity)
    {
        base.FuelQuantity += quantity * 0.95;
    }
}
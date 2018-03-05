using System;

public class Truck : Vehicle
{
    public Truck(double fuelQuantity, double litersPerKm, double tankCapacity)
        : base(fuelQuantity, litersPerKm, tankCapacity)
    {
    }

    public override double LitersPerKm => base.LitersPerKm + 1.6;

    public override void Refuel(double quantity)
    {
        if (quantity <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }

        else if (base.FuelQuantity + quantity * 0.95 > base.TankCapacity)
        {
            throw new ArgumentException($"Cannot fit {quantity} fuel in the tank");
        }

        base.FuelQuantity += quantity * 0.95;

    }
}
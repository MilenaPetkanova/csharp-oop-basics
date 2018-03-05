using System;

public abstract class Vehicle : IVehicle
{
    private double tankCapacity;
    private double litersPerKm;
    private double fuelQuantity;

    public Vehicle(double fuelQuantity, double litersPerKm, double tankCapacity)
    {
        this.TankCapacity = tankCapacity;
        this.LitersPerKm = litersPerKm;
        this.FuelQuantity = fuelQuantity;
    }

    public virtual double TankCapacity
    {
        get => this.tankCapacity;
        private set => this.tankCapacity = value;
    }

    public virtual double LitersPerKm
    {
        get => this.litersPerKm;
        protected set => this.litersPerKm = value;
    }

    public virtual double FuelQuantity
    {
        get => this.fuelQuantity;
        protected set
        {
            if (value > this.tankCapacity)
            {
                this.fuelQuantity = 0;
            }
            else
            {
                this.fuelQuantity = value;
            }
        }
    }

    public virtual string Drive(double distance)
    {
        var fuelNeeded = distance * this.LitersPerKm;

        if (this.fuelQuantity - fuelNeeded < 0)
        {
            return $"{this.GetType()} needs refueling";
        }
        else
        {
            this.fuelQuantity -= fuelNeeded;
            return $"{this.GetType()} travelled {distance} km";
        }
    }

    public virtual void Refuel(double quantity)
    {
        if (quantity <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }
        else if (this.fuelQuantity + quantity > this.tankCapacity)
        {
            throw new ArgumentException($"Cannot fit {quantity} fuel in the tank");
        }
        this.FuelQuantity += quantity;
    }

    public override string ToString()
    {
        return $"{this.GetType()}: {this.FuelQuantity:F2}";
    }

}
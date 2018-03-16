using System;

public class Car 
{
    private const double TANK_MAX_CAPACITY = 160;

    private double fuelAmount;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int Hp { get; private set; }

    public Tyre Tyre { get; private set; }

    public double FuelAmount
    {
        get => this.fuelAmount;
        private set
        {
            if (value > TANK_MAX_CAPACITY)
            {
                this.fuelAmount = TANK_MAX_CAPACITY;
            }
            else if (value < 0)
            {
                throw new ArgumentException(OutputMessages.OutOfFuel);
            }
            else
            {
                this.fuelAmount = value;
            }
        }
    }

    internal void ChangeTyres(Tyre tyre)
    {
        this.Tyre = tyre;
    }

    internal void Refuel(double fuelAmount)
    {
        this.FuelAmount += fuelAmount;
    }

    internal void CompleteLap(int trackLength, double fuelConsumptionPerKm)
    {
        this.FuelAmount -= trackLength * fuelConsumptionPerKm;

        this.Tyre.ReduceDegradation();
    }
}
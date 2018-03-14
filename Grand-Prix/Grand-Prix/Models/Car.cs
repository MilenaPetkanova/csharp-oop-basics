using System;

public class Car : ICar
{
    private double fuelAmount;

    public Car(int hp, double fuealAmount, Tyre tyre)
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
            if (value > 160)
            {
                this.fuelAmount = 160;
            }
            CheckFuelAmount();
            this.fuelAmount = value;
        }
    }

    public void CheckFuelAmount()
    {
        if (this.fuelAmount < 0)
        {
            throw new ArgumentException("");
        }
    }
}
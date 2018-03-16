using System;
using System.Collections.Generic;

public abstract class Driver 
{
    private const double boxDefaultTime = 20;

    protected Driver(string name, Car car, double fuelConsumptionPerKm)
    {
        this.Name = name;
        this.Car = car;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        this.TotalTime = 0d;
        this.IsRacing = true;
    }

    public string Name { get; }

    public double TotalTime { get; set; }

    public Car Car { get; private set; }

    public double FuelConsumptionPerKm { get; protected set; }

    public virtual double Speed => (this.Car.Hp + this.Car.Tyre.Degradation) / Car.FuelAmount;

    public string Status => IsRacing ? this.TotalTime.ToString("F3") : this.FailureReason;

    public bool IsRacing { get; private set; }

    public string FailureReason { get; private set; }

    public override string ToString()
    {
        return $"{this.Name} {this.Status}";
    }

    public void Box()
    {
        this.TotalTime += boxDefaultTime;
    }

    public void ChangeTyres(List<string> args)
    {
        this.Box();
        Tyre tyre = TyreFactory.CreateTyre(args);
        this.Car.ChangeTyres(tyre);
    }

    public void Refuel(List<string> args)
    {
        this.Box();
        double fuelAmount = double.Parse(args[0]);
        this.Car.Refuel(fuelAmount);
    }

    public void CompleteLap(int trackLength)
    {
        this.TotalTime += 60 / (trackLength / this.Speed);
        this.Car.CompleteLap(trackLength, this.FuelConsumptionPerKm);
    }

    public void ReduceTotalTime(double timeAmount)
    {
        this.TotalTime -= timeAmount;
    }

    internal void Fail(string message)
    {
        this.IsRacing = false;
        this.FailureReason = message;
    }

}
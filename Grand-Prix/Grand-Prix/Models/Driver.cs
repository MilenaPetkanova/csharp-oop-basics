public abstract class Driver : IDriver
{
    protected Driver(string name, Car car)
    {
        this.Name = name;
        this.Car = car;
    }

    public string Name { get; protected set; }

    public double TotalTime { get; protected set; }

    public Car Car { get; protected set; }

    public double FuelConsumptionPerKm { get; protected set; }

    public double Speed { get; protected set; }

    public void UpdateSpeed()
    {
        this.Speed = (this.Car.Hp + this.Car.Tyre.Degradation) / Car.FuelAmount;
    }
}
public abstract class Driver 
{
    protected Driver(string name, Car car, double fuelConsumptionPerKm)
    {
        this.Name = name;
        this.Car = car;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        this.TotalTime = 0d;
    }

    public string Name { get; }

    public double TotalTime { get; private set; }

    public Car Car { get; private set; }

    public double FuelConsumptionPerKm { get; protected set; }

    public virtual double Speed => (this.Car.Hp + this.Car.Tyre.Degradation) / Car.FuelAmount;
}
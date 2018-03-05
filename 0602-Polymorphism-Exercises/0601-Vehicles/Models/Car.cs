public class Car : Vehicle
{
    private double litersPerKm;

    public Car(double fuelQuantity, double litersPerKm) 
        : base(fuelQuantity, litersPerKm)
    {
    }

    public override double LitersPerKm => base.LitersPerKm + 0.9;
}
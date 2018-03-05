public interface IVehicle 
{
    double FuelQuantity { get; }

    double LitersPerKm { get; }

    string Drive(double distance);

    void Refuel(double quantity);
}
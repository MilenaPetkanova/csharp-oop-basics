namespace StorageMaster.Interfaces
{
    using StorageMaster.Models.Products;
    using StorageMaster.Models.Storage;
    using StorageMaster.Models.Vehicles;
    using System.Collections.Generic;

    public interface IStorage
    {
        string Name { get; }
        int Capacity { get; }
        int GarageSlots { get; }
        bool IsFull { get; }
        IReadOnlyCollection<Product> Products { get; }
        IReadOnlyCollection<Vehicle> Vehicles { get; }

        Vehicle GetVehicle(int garageSlot);
        int SendVehicleTo(int garageSlot, Storage deliveryLocation);
        int UnloadVehicle(int garageSlot);
    }
}

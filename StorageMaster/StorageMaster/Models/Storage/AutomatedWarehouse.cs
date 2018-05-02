namespace StorageMaster.Models.Storage
{
    using System.Collections.Generic;
    using StorageMaster.Interfaces;
    using StorageMaster.Models.Vehicles;
    using StorageMaster.Factories;

    public class AutomatedWarehouse : Storage
    {
        private const int DefaultCapacity = 1;
        private const int DefaultSlots = 2;
        private const int VehiclesCount = 1;
        private const string VehicleType = "Truck";

        private static IEnumerable<Vehicle> defaultVehicles =
            new List<Vehicle>
            {
                new Truck()
            };

        public AutomatedWarehouse(string name) 
            : base(name, DefaultCapacity, DefaultSlots, defaultVehicles)
        {
            var factory = new VehicleFactory();
            var thisVehicles = factory.CreateVehicle(VehicleType);
        }

        //private IEnumerable<Vehicle> InitVehicles()
        //{
        //    List<Vehicle>  vehicles = new List<Vehicle>();
        //    for (int i = 0; i < VehiclesCount; i++)
        //    {
        //        var vehicle = new Truck();
        //        vehicles.Add(vehicle);
        //    }

        //    return vehicles;
        //}
    }
}

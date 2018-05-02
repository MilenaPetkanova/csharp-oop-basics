namespace StorageMaster.Models.Storage
{
    using System.Collections.Generic;
    using StorageMaster.Interfaces;
    using StorageMaster.Models.Vehicles;

    public class DistributionCenter : Storage
    {
        private const int DefaultCapacity = 2;
        private const int DefaultSlots = 5;
        private const int VehiclesCount = 3;

        private static IEnumerable<Vehicle> defaultVehicles =
            new List<Vehicle>
            {
                new Van(),
                new Van(),
                new Van()
            };

        public DistributionCenter(string name)
            : base(name, DefaultCapacity, DefaultSlots, defaultVehicles)
        {
        }

        //private static IEnumerable<Vehicle> InitVehicles()
        //{
        //    List<Vehicle> vehicles = new List<Vehicle>();
        //    for (int i = 0; i < VehiclesCount; i++)
        //    {
        //        var vehicle = new Van();
        //        vehicles.Add(vehicle);
        //    }

        //    return vehicles;
        //}
    }
}

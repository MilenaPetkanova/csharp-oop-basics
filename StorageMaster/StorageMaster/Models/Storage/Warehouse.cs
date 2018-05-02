namespace StorageMaster.Models.Storage
{
    using System.Collections.Generic;
    using StorageMaster.Interfaces;
    using StorageMaster.Models.Vehicles;

    public class Warehouse : Storage
    {
        private const int DefaultCapacity = 10;
        private const int DefaultSlots = 10;
        private const int VehiclesCount = 3;

        private static IEnumerable<Vehicle> defaultVehicles =
            new List<Vehicle>
            {
                new Semi(),
                new Semi(),
                new Semi()
            };

        public Warehouse(string name)
            : base(name, DefaultCapacity, DefaultSlots, defaultVehicles)
        {
        }

        //private static IEnumerable<Vehicle> InitVehicles()
        //{
        //    List<Vehicle> vehicles = new List<Vehicle>();
        //    for (int i = 0; i < VehiclesCount; i++)
        //    {
        //        var vehicle = new Semi();
        //        vehicles.Add(vehicle);
        //    }

        //    return vehicles;
        //}
    }
}

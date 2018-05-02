namespace StorageMaster.Factories
{
    using StorageMaster.Models.Storage;
    using System;

    public class StorageFactory
    {
        private const string InvalidTypeMessage = "Invalid storage type!";

        public Storage CreateStorage(string type, string name)
        {
            switch (type)
            {
                case "AutomatedWarehouse":
                    return new AutomatedWarehouse(name);
                case "DistributionCenter":
                    return new DistributionCenter(name);
                case "Warehouse":
                    return new Warehouse(name);
                default:
                    throw new InvalidOperationException(InvalidTypeMessage);
            }
        }
    }
}

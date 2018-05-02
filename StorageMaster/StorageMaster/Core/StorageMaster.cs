namespace StorageMaster.Core
{
    using global::StorageMaster.Factories;
    using global::StorageMaster.Models.Products;
    using global::StorageMaster.Models.Storage;
    using global::StorageMaster.Models.Vehicles;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StorageMaster
    {
        private List<Storage> storageRegistry;
        private List<Product> productsPool;
        private Vehicle currentVehicle;
        private ProductFactory productFactory;
        private VehicleFactory vehicleFactory;
        private StorageFactory storageFactory;

        public StorageMaster()
        {
            this.storageRegistry = new List<Storage>();
            this.productsPool = new List<Product>();
            this.productFactory = new ProductFactory();
            this.vehicleFactory = new VehicleFactory();
            this.storageFactory = new StorageFactory();
        }

        public string AddProduct(string type, double price)
        {
            var product = this.productFactory.CreateProduct(type, price);
            this.productsPool.Add(product);

            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            var storage = this.storageFactory.CreateStorage(type, name);
            this.storageRegistry.Add(storage);

            return $"Registered {name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            var storage = this.storageRegistry.First(s => s.Name == storageName);
            this.currentVehicle = storage.GetVehicle(garageSlot);

            return $"Selected {currentVehicle.GetType().Name}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            var loadedProductsCount = 0;
            var productCount = productNames.Count();

            foreach (var productName in productNames)
            {
                var product = this.productsPool.FirstOrDefault(p => p.GetType().Name.Equals(productName));
                if (product == null)
                {
                    throw new InvalidOperationException($"{productName} is out of stock!");
                }

                var last = this.productsPool.Where(p => p.GetType().Name.Equals(productName)).Last();
                this.productsPool.Remove(last);
                this.currentVehicle.LoadProduct(last);
                loadedProductsCount++;
            }

            return $"Loaded {loadedProductsCount}/{productCount} products into {currentVehicle.GetType().Name}";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            var sourceStorage = this.storageRegistry.FirstOrDefault(s => s.Name.Equals(sourceName));
            var destinationStorage = this.storageRegistry.FirstOrDefault(s => s.Name.Equals(destinationName));

            if (destinationStorage == null)
            {
                throw new InvalidOperationException($"Invalid destination storage!");
            }

            else if (sourceStorage == null)
            {
                throw new InvalidOperationException($"Invalid source storage!");
            }

            var vehicle = sourceStorage.GetVehicle(sourceGarageSlot);

            int slot = sourceStorage.SendVehicleTo(sourceGarageSlot, destinationStorage);

            return $"Sent {vehicle.GetType().Name} to {destinationName} (slot {slot})";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            var storage = this.storageRegistry.FirstOrDefault(s => s.Name.Equals(storageName));
            if (storage == null)
            {
                throw new ArgumentException($"Invalid storage name!");
            }

            var vehicle = storage.GetVehicle(garageSlot);
            var productsInVehicle = vehicle.Trunk.Count();

            var unloadedProductsCount = storage.UnloadVehicle(garageSlot);

            return $"Unloaded {unloadedProductsCount}/{productsInVehicle} products at {storageName}";
        }

        public string GetStorageStatus(string storageName)
        {
            var storage = this.storageRegistry.FirstOrDefault(s => s.Name.Equals(storageName));
            if (storage == null)
            {
                throw new ArgumentException($"Invalid storage name!");
            }

            var productsCount = storage.Products.Count;

            var products = storage.Products
                .GroupBy(x => x.GetType().Name);

            var sortedProducts = products.GroupBy(x => x.GetType().Name)
                .ToDictionary(t => t.Key, t => t.ToList());

            var prWeight = storage.Products.Sum(p => p.Weight);
            var prCapacity = storage.Capacity;

            var result = $"Stock ({prWeight}/{prCapacity}): [{0}]";

            return result;
        }

        public string GetSummary()
        {
            var sb = new StringBuilder();
            foreach (var storage in this.storageRegistry.OrderByDescending(s => s.Products.Sum(p => p.Price)))
            {
                sb.AppendLine($"{storage.Name}:");
                sb.AppendLine($"Storage worth: ${storage.Products.Sum(p => p.Price):F2}");
            }

            return sb.ToString().Trim();
        }

    }
}

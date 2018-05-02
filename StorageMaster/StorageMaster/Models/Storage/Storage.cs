namespace StorageMaster.Models.Storage
{
    using StorageMaster.Interfaces;
    using StorageMaster.Models.Products;
    using StorageMaster.Models.Vehicles;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Storage : IStorage
    {
        private const string FullStorageMessage = "Storage is full!";
        private const string InvalidGarageSlot = "Invalid garage slot!";
        private const string EmptySlotMessage = "No vehicle in this garage slot!!";
        private const string NoGarageRoom = "No room in garage!";

        private bool isFull;
        protected List<Vehicle> vehicles;
        private List<Product> products;
        private List<Vehicle> garage;

        protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;

            this.vehicles = vehicles.ToList();
            InitGarage();

            this.products = new List<Product>();
        }

        private void InitGarage()
        {
            this.garage = new List<Vehicle>();
            for (int i = 0; i < this.GarageSlots; i++)
            {
                if (i < this.vehicles.Count)
                {
                    this.garage.Add(this.vehicles[i]);
                }
                else
                {
                    this.garage.Add(null); ;
                }
            }
        }

        public string Name { get; }

        public int Capacity { get; }

        public int GarageSlots { get; }

        public bool IsFull
        {
            get => this.isFull;
            private set
            {
                var productsWeights = this.products.Sum(p => p.Weight);
                if (productsWeights < this.Capacity)
                {
                    this.isFull = false;
                }
                this.isFull = true;
            }
        }

        public IReadOnlyCollection<Product> Products => this.products.AsReadOnly();

        public IReadOnlyCollection<Vehicle> Vehicles => this.vehicles.AsReadOnly();

        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= this.GarageSlots)
            {
                throw new InvalidOperationException(InvalidGarageSlot);
            }
            else if (this.garage.ElementAtOrDefault(garageSlot) == null)
            {
                throw new InvalidOperationException(EmptySlotMessage);
            }
            var vehicle = this.garage.ElementAt(garageSlot);
            return vehicle;
        }


        // SOLVED: the garage slot in the source storage is freed ?
        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            var vehicle = this.GetVehicle(garageSlot);

            var freeSlotsIndexes = new List<int>();
            for (int i = 0; i < deliveryLocation.garage.Count; i++)
            {
                if (deliveryLocation.garage[i] == null)
                {
                    freeSlotsIndexes.Add(i);
                }
            }

            if (!freeSlotsIndexes.Any())
            {
                throw new InvalidOperationException(NoGarageRoom);
            }

            var firstFreeIndex = freeSlotsIndexes.First();
            deliveryLocation.garage[firstFreeIndex] = vehicle;

            return firstFreeIndex;
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (this.isFull)
            {
                throw new InvalidOperationException(FullStorageMessage);
            }

            var vehicle = this.GetVehicle(garageSlot);

            var uploadedProducts = 0;
            while (!vehicle.IsEmpty || this.IsFull)
            {
                var product = vehicle.Unload();
                this.products.Add(product);
                uploadedProducts++;
            }

            return uploadedProducts;
        }
    }
}

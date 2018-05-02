namespace StorageMaster.Models.Vehicles
{
    using StorageMaster.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using StorageMaster.Models.Products;

    public abstract class Vehicle : IVehicle
    {
        private const string FullVehicleMessage = "Vehicle is full!";
        private const string EmptyVehicleMessage = "No products left in vehicle!";

        private List<Product> trunk;
        private bool isFull;
        private bool isEmpty;

        protected Vehicle(int capacity)
        {
            this.Capacity = capacity;
            this.trunk = new List<Product>();
        }

        public int Capacity { get; private set; }

        public IReadOnlyCollection<Product> Trunk => this.trunk.AsReadOnly();

        public bool IsFull
        {
            get => this.isFull;
            private set
            {
                var productsWeights = this.trunk.Sum(p => p.Weight);
                if (productsWeights < this.Capacity)
                {
                    this.isFull = false; 
                }
                this.isFull = true;
            }
        }

        public bool IsEmpty => this.trunk.Count <= 0;

        public void LoadProduct(Product product)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException(FullVehicleMessage);
            }
            this.trunk.Add(product);
        }

        public Product Unload()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException(EmptyVehicleMessage);
            }
            var lastProduct = this.trunk.Last();
            this.trunk.Remove(lastProduct);
            return lastProduct;
        }
    }
}

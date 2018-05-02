namespace StorageMaster.Models.Products
{
    using StorageMaster.Interfaces;
    using System;

    public abstract class Product : IProduct
    {
        private const string InvalidPriceMessage = "Price cannot be negative!";

        private double price;
        private double weight;

        protected Product(double price, double weight)
        {
            this.Price = price;
            this.Weight = weight;
        }

        public double Price
        {
            get => this.price;
            set
            {
                // ? <=
                if (value < 0)
                {
                    throw new InvalidOperationException(InvalidPriceMessage);
                }
                price = value;
            }
        }

        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }
    }
}

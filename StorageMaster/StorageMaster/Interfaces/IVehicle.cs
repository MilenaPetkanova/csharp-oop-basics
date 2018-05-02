namespace StorageMaster.Interfaces
{
    using StorageMaster.Models.Products;
    using System.Collections.Generic;

    public interface IVehicle
    {
        int Capacity { get; }
        IReadOnlyCollection<Product> Trunk { get; }
        bool IsFull { get; }
        bool IsEmpty { get; }

        void LoadProduct(Product product);
        Product Unload();
    }
}

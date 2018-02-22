using System;
using System.Collections.Generic;
using System.Linq;

public class Person
{
    private string name;
    private decimal money;

    public List<Product> BagOfProducts { get; set; }

    public string Name
    {
        get => this.name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            this.name = value;
        }
    }

    public decimal Money
    {
        get => this.money;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            this.money = value;
        }
    }

    public Person(string name, decimal money)
    {
        this.Name = name;
        this.Money = money;
        this.BagOfProducts = new List<Product>();
    }

    public string BuyProduct(Product product)
    {
        if (this.money >= product.Cost)
        {
            this.BagOfProducts.Add(product);
            this.money -= product.Cost;
            return $"{this.name} bought {product.Name}";
        }
        else
        {
            return $"{this.name} can't afford {product.Name}";
        }
    }

    public override string ToString()
    {
        if (this.BagOfProducts.Count > 0)
        {
            return $"{this.name} - {string.Join(", ", this.BagOfProducts.Select(p => p.Name))}";
        }
        else
        {
            return $"{this.name} - Nothing bought";
        }
    }
}
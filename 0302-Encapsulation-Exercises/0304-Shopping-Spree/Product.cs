using System;

public class Product
{
    private string name;
    private decimal cost;

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

    public decimal Cost
    {
        get => this.cost;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            this.cost = value;
        }
    }

    public Product(string name, decimal cost)
    {
        this.Name = name;
        this.Cost = cost;
    }

    public override string ToString()
    {
        return this.name.ToString();
    }
}
using System;
using System.Collections.Generic;

public class Topping
{
    private Dictionary<string, double> validToppings = 
        new Dictionary<string, double>
        {
            ["meat"] = 1.2,
            ["veggies"] = 0.8,
            ["cheese"] = 1.1,
            ["sauce"] = 0.9
        };
    private string type;
    private int weight;

    private string Type
    {
        get => this.type;
        set
        {
            if (!validToppings.ContainsKey(value.ToLower()))
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            this.type = value;
        }
    }
    private int Weight
    {
        get => this.weight;
        set
        {
            if (value < 1 || value > 50)
            {
                throw new ArgumentException($"{this.type} weight should be in the range [1..50].");
            }
            this.weight = value;
        }
    }

    public Topping(string type, int weight)
    {
        this.Type = type;
        this.Weight = weight;
    }

    public double TotalCalories
    {
        get { return this.Weight * 2 * this.validToppings[this.Type.ToLower()]; }
    }
}
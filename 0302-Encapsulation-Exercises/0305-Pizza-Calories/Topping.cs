using System;
using System.Collections.Generic;

public class Topping
{
    private const int MIN_WEIGHT = 1;
    private const int MAX_WEIGHT = 50;
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
                throw new ArgumentException($"{this.type} weight should be in the range [{MIN_WEIGHT}..{MAX_WEIGHT}].");
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
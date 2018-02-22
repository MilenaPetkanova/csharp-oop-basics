using System;
using System.Collections.Generic;
using System.Linq;

public class Pizza 
{
    private string name;
    private Dough dough;
    private List<Topping> toppings;

    public string Name
    {
        get => this.name;
        private set
        {
            if (string.IsNullOrEmpty(value) || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
            this.name = value;
        }
    }

    public Dough Dough
    {
        get => this.dough;
        private set { dough = value; }
    }

    public int ToppingCount => this.toppings.Count;

    public Pizza(string name, Dough dough)
    {
        this.Name = name;
        this.Dough = dough;
        this.toppings = new List<Topping>();
    }

    public void AddTopping(Topping topping)
    {
        this.toppings.Add(topping);
        if (this.toppings.Count > 10)
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }
    }

    private double TotalCalories
    {
        get { return this.dough.TotalCalories + this.toppings.Sum(t => t.TotalCalories); }
    }

    public override string ToString()
    {
        return $"{this.name} - {this.TotalCalories:F2} Calories.";
    }

}
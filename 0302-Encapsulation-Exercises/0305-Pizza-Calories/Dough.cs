using System;
using System.Collections.Generic;
using System.Linq;

public class Dough 
{
    private Dictionary<string, double> validFlourTypes =
        new Dictionary<string, double>
        {
            ["white"] = 1.5,
            ["wholegrain"] = 1.0
        };
    private Dictionary<string, double> validBakingTechniques =
        new Dictionary<string, double>
        {
            ["crispy"] = 0.9,
            ["chewy"] = 1.1,
            ["homemade"] = 1.0
        };
    private string flourType;
    private string bakingTechnique;
    private int weight;

    private string FlourType
    {
        get => this.flourType;
        set
        {
            if (!validFlourTypes.Any(t => t.Key == value.ToLower()))
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            this.flourType = value;
        }
    }

    private string BakingTechnique
    {
        get => this.bakingTechnique;
        set
        {
            if (!validBakingTechniques.ContainsKey(value.ToLower()))
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            this.bakingTechnique = value;
        }
    }

    private int Weight
    {
        get => this.weight;
        set
        {
            if (value < 1 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
            this.weight = value;
        }
    }

    public Dough(string flourType, string bakingTechnique, int weight)
    {
        this.FlourType = flourType;
        this.BakingTechnique = bakingTechnique;
        this.Weight = weight;
    }

    public double TotalCalories
    {
        get { return this.Weight * 2 * this.validFlourTypes[this.FlourType.ToLower()]
                * this.validBakingTechniques[this.bakingTechnique.ToLower()]; }
    }
}
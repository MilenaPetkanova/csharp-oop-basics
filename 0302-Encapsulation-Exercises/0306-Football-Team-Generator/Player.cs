using System;
using System.Collections.Generic;
using System.Linq;

public class Player
{
    private string name;
    private Dictionary<string, int> stats =
        new Dictionary<string, int>
        {
            {"Endurance", 0},
            {"Sprint", 0},
            {"Dribble", 0},
            {"Passing", 0},
            {"Shooting", 0}
        };

    public string Name
    {
        get => this.name;
        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }
            this.name = value;
        }
    }

    public Dictionary<string, int> Stats => this.stats;

    public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
    {
        this.Name = name;
        this.stats["Endurance"] = endurance;
        this.stats["Sprint"] = sprint;
        this.stats["Dribble"] = dribble;
        this.stats["Passing"] = passing;
        this.stats["Shooting"] = shooting;
        if (endurance < 0 || endurance > 100 || sprint < 0 || sprint > 100 || dribble < 0 || dribble > 100
            || passing < 0 || passing > 100 || shooting < 0 || shooting > 100)
        {
            throw new ArgumentException($"{this.stats.First(s => s.Value < 0 || s.Value > 100).Key}" +
                $" should be between 0 and 100.");
        }
    }

}
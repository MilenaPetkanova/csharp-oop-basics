using System;
using System.Collections.Generic;
using System.Linq;

public class Team 
{
    private string teamName;
    private int rating;
    private List<Player> players;

    public string TeamName
    {
        get => this.teamName;
        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }
            this.teamName = value;
        }
    }

    public int Rating
    {
        get => this.rating = CalculateRating();
        set => this.rating = CalculateRating();
    }

    public Team(string teamName)
    {
        this.TeamName = teamName;
        this.players = new List<Player>();
        this.rating = this.Rating;
    }

    public void AddPlayer(Player player)
    {
        players.Add(player);
    }

    public void RemovePlayer(string name)
    {
        if (!this.players.Any(p => p.Name == name))
        {
            throw new ArgumentException($"Player {name} is not in {this.teamName} team.");
        }
        players.Remove(players.First(p => p.Name == name));
    }

    private int CalculateRating()
    {
        double rating = 0;
        foreach (var player in this.players)
        {
            rating += player.Stats.Values.Sum();
        }
        rating /= 5;
        int result = (int)Math.Round(rating);
        return result;
    }
}
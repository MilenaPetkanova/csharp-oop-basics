using System;
using System.Collections.Generic;
using System.Linq;

class Startup
{
    static void Main()
    {

        var allTeams = new List<Team>();

        string inputLine;
        while ((inputLine = Console.ReadLine()) != "END")
        {
            try
            {
                var tokens = inputLine.Split(';');
                var command = tokens[0];
                var teamName = tokens[1];
                if (command != "Team" && !allTeams.Any(t => t.TeamName == teamName))
                {
                    throw new ArgumentException($"Team {teamName} does not exist.");
                }
                switch (command)
                {
                    case "Team":
                        var newTeam = new Team(teamName);
                        allTeams.Add(newTeam);
                        break;
                    case "Add":
                        var playerName = tokens[2];
                        var endurance = int.Parse(tokens[3]);
                        var sprint = int.Parse(tokens[4]);
                        var dribble = int.Parse(tokens[5]);
                        var passing = int.Parse(tokens[6]);
                        var shooting = int.Parse(tokens[7]);
                        var player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                        var existingTeam = allTeams.FirstOrDefault(t => t.TeamName == teamName);
                        existingTeam.AddPlayer(player);
                        break;
                    case "Remove":
                        var name = tokens[2];
                        existingTeam = allTeams.FirstOrDefault(t => t.TeamName == teamName);
                        existingTeam.RemovePlayer(name);
                        break;
                    case "Rating":
                        var team = allTeams.FirstOrDefault(t => t.TeamName == teamName);
                        Console.WriteLine($"{team.TeamName} - {team.Rating}");
                        break;
                    default:
                        break;
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

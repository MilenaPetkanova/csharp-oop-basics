using System;
using System.Collections.Generic;

class Startup
{
    static void Main()
    {
        var lines = int.Parse(Console.ReadLine());
        var people = new List<Person>();
        for (int i = 0; i < lines; i++)
        {
            var cmdArgs = Console.ReadLine().Split();
            try
            {
                var person = new Person(cmdArgs[0], cmdArgs[1], int.Parse(cmdArgs[2]), decimal.Parse(cmdArgs[3]));
                people.Add(person);
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine(argEx.Message);
            }
        }

        var team = new Team("SoftUniTeam");
        foreach (var person in people)
        {
            team.AddPlayer(person);
        }

        Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
        Console.WriteLine($"Reserved team has {team.ReserveTeam.Count} players.");
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private RaceTower raceTower;

    public Engine()
    {
        this.raceTower = new RaceTower();
    }

    public void Run()
    {
        int lapsNumber = int.Parse(Console.ReadLine());
        int trackLength = int.Parse(Console.ReadLine());
        raceTower.SetTrackInfo(lapsNumber, trackLength);

        while (raceTower.IsRaceOver == false)
        {
            var commandLine = Console.ReadLine().Split();
            var command = commandLine[0];
            var commandArgs = commandLine.Skip(1).ToList();

            switch (command)
            {
                case "RegisterDriver":
                    raceTower.RegisterDriver(commandArgs);
                    break;
                case "Box":
                    raceTower.DriverBoxes(commandArgs);
                    break;
                case "CompleteLaps":
                    string result = this.raceTower.CompleteLaps(commandArgs);
                    if (!string.IsNullOrWhiteSpace(result))
                    {
                        Console.WriteLine(result);
                    }
                    break;
                case "Leaderboard":
                    Console.WriteLine(raceTower.GetLeaderboard());
                    break;
                case "ChangeWeather":
                    raceTower.ChangeWeather(commandArgs);
                    break;
            }
        }
    }
}
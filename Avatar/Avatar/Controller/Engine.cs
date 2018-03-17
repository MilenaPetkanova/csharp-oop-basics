using System;
using System.Linq;

public class Engine
{
    private NationsBuilder nationbulder;

    public Engine()
    {
        this.nationbulder = new NationsBuilder();
    }

    public void Run()
    {
        var inputLine = string.Empty;
        while ((inputLine = Console.ReadLine()) != "Quit")
        {
            var command = inputLine.Split().First().ToString();
            var commandArgs = inputLine.Split().Skip(1).ToList();

            switch (command)
            {
                case "Bender":
                    nationbulder.AssignBender(commandArgs);
                    break;
                case "Monument":
                    nationbulder.AssignMonument(commandArgs);
                    break;
                case "Status":
                    Console.WriteLine(nationbulder.GetStatus(commandArgs[0]));
                    break;
                case "War":
                    nationbulder.IssueWar(commandArgs[0]);
                    break;
            }
        }

        PrintFinalOutput();
    }

    private void PrintFinalOutput()
    {
        Console.WriteLine(nationbulder.GetWarsRecord());
    }
}
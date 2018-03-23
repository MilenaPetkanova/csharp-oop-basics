using System;
using System.Linq;

public class Engine
{
    private DungeonMaster dungeonMaster;
    private bool isRunning;

    public Engine()
    {
        this.dungeonMaster = new DungeonMaster();
        this.isRunning = true;
    }

    public void Run()
    {
        while (this.isRunning)
        {
            var inputLine = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(inputLine))
            {
                this.isRunning = false;
                continue;
            }

            var commandArgs = inputLine.Split();
            var command = commandArgs[0];
            var args = null ?? inputLine.Split().Skip(1).ToArray();

            if (command.Equals("IsGameOver"))
            {
                this.isRunning = false;
                continue;
            }

            try
            {
                ExecuteCommand(command, args);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine("Parameter Error: " + ae.Message);
            }
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine("Invalid Operation: " + ioe.Message);
            }
        }

        Console.WriteLine("Final stats:");
        Console.WriteLine(this.dungeonMaster.GetStats());
    }

    private void ExecuteCommand(string command, string[] args)
    {
        var output = string.Empty;
        switch (command)
        {
            case "JoinParty":
                output = this.dungeonMaster.JoinParty(args);
                break;
            case "AddItemToPool":
                output = this.dungeonMaster.AddItemToPool(args);
                break;
            case "PickUpItem":
                output = this.dungeonMaster.PickUpItem(args);
                break;
            case "UseItem":
                output = this.dungeonMaster.UseItem(args);
                break;
            case "GiveCharacterItem":
                output = this.dungeonMaster.GiveCharacterItem(args);
                break;
            case "UseItemOn":
                output = this.dungeonMaster.UseItemOn(args);
                break;
            case "GetStats":
                output = this.dungeonMaster.GetStats();
                break;
            case "Attack":
                output = this.dungeonMaster.Attack(args);
                break;
            case "Heal":
                output = this.dungeonMaster.Heal(args);
                break;
            case "EndTurn":
                output = this.dungeonMaster.EndTurn(args);
                break;
            default:
                throw new ArgumentException("Invalid command!");
        }

        if (output != string.Empty)
        {
            Console.WriteLine(output);
        }
    }
}

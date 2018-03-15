using System;
using System.Linq;

class Startup
{
    static void Main()
    {
        var draft = new DraftManager();

        bool turnOn = true;
        while (turnOn)
        {
            var inputLine = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var command = inputLine[0];
            var parameters = inputLine.Skip(1).ToList();

            try
            {
                switch (command)
                {
                    case "RegisterHarvester":
                        Console.WriteLine(draft.RegisterHarvester(parameters));
                        break;
                    case "RegisterProvider":
                        Console.WriteLine(draft.RegisterProvider(parameters));
                        break;
                    case "Day":
                        Console.WriteLine(draft.Day());
                        break;
                    case "Mode":
                        Console.WriteLine(draft.Mode(parameters));
                        break;
                    case "Check":
                        Console.WriteLine(draft.Check(parameters));
                        break;
                    case "Shutdown":
                        Console.WriteLine(draft.ShutDown());
                        turnOn = false;
                        return;
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

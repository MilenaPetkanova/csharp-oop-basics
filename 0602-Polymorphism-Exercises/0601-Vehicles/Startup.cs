using System;

class Startup
{
    static void Main()
    {
        var carParams = Console.ReadLine().Split();
        Vehicle car = new Car(double.Parse(carParams[1]), double.Parse(carParams[2]));

        var truckParams = Console.ReadLine().Split();
        Vehicle truck = new Truck(double.Parse(truckParams[1]), double.Parse(truckParams[2]));

        int commandsCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < commandsCount; i++)
        {
            var vehicleArgs = Console.ReadLine().Split();
            var command = vehicleArgs[0];
            var vehicleType = vehicleArgs[1];
            var amount = double.Parse(vehicleArgs[2]);

            if (vehicleType.Equals("Car"))
            {
                ProceedCommand(car, command, amount);
            }
            else if (vehicleType.Equals("Truck"))
            {
                ProceedCommand(truck, command, amount);
            }
        }

        Console.WriteLine(car);
        Console.WriteLine(truck);
    }

    private static void ProceedCommand(Vehicle vehicle, string command, double amount)
    {
        if (command.Equals("Drive"))
        {
            Console.WriteLine(vehicle.Drive(amount));
        }
        else if (command.Equals("Refuel"))
        {
            vehicle.Refuel(amount);
        }
    }
}

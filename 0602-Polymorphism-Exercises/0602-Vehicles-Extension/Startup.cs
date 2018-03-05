using System;

class Startup
{
    static void Main()
    {
        var carParams = Console.ReadLine().Split();
        Vehicle car = new Car(double.Parse(carParams[1]), double.Parse(carParams[2]), double.Parse(carParams[3]));

        var truckParams = Console.ReadLine().Split();
        Vehicle truck = new Truck(double.Parse(truckParams[1]), double.Parse(truckParams[2]), double.Parse(truckParams[3]));

        var busParams = Console.ReadLine().Split();
        Vehicle bus = new Bus(double.Parse(busParams[1]), double.Parse(busParams[2]), double.Parse(busParams[3]));

        int commandsCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < commandsCount; i++)
        {
            var vehicleArgs = Console.ReadLine().Split();
            var command = vehicleArgs[0];
            var vehicleType = vehicleArgs[1];
            var amount = double.Parse(vehicleArgs[2]);

            try
            {
                if (vehicleType.Equals("Car"))
                {
                    ProceedCommand(car, command, amount);
                }
                else if (vehicleType.Equals("Truck"))
                {
                    ProceedCommand(truck, command, amount);
                }
                else if (vehicleType.Equals("Bus"))
                {
                    ProceedCommand(bus, command, amount);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        Console.WriteLine(car);
        Console.WriteLine(truck);
        Console.WriteLine(bus);
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
        else if (command.Equals("DriveEmpty"))
        {
            Console.WriteLine(((Bus)vehicle).DriveEmpty(amount));
        }
    }
}

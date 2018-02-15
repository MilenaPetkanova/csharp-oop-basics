using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var cars = new List<Car>();

        int carsAmount = int.Parse(Console.ReadLine());
        for (int i = 0; i < carsAmount; i++)
        {
            var input = Console.ReadLine().Split();
            string model = input[0];
            int engineSpeed = int.Parse(input[1]);
            int enginePower = int.Parse(input[2]);
            int cargoWeight = int.Parse(input[3]);
            string cargoType = input[4];
            double tire1Pressure = double.Parse(input[5]);
            int tire1Age = int.Parse(input[6]);
            double tire2Pressure = double.Parse(input[7]);
            int tire2Age = int.Parse(input[8]);
            double tire3Pressure = double.Parse(input[9]);
            int tire3Age = int.Parse(input[10]);
            double tire4Pressure = double.Parse(input[11]);
            int tire4Age = int.Parse(input[12]);

            var car = new Car(model, engineSpeed, enginePower,cargoWeight, cargoType,
        tire1Pressure, tire1Age, tire2Pressure, tire2Age, tire3Pressure, tire3Age, tire4Pressure, tire4Age);

            cars.Add(car);
        }

        var command = Console.ReadLine();

        switch (command)
        {
            case "fragile":
                PrintFragileCars(cars, command);
                break;
            case "flamable":
                PrintFlamableCars(cars, command);
                break;
            default:
                break;
        }
    }

    private static void PrintFlamableCars(List<Car> cars, string command)
    {
        var flambleCars = cars
            .Where(c => c.Cargo.CargoType == command)
            .Where(c => c.Engine.EnginePower > 250);

        foreach (var car in flambleCars)
        {
            Console.WriteLine($"{car.Model}");
        }
    }

    private static void PrintFragileCars(List<Car> cars, string command)
    {
        var fragileCars = cars
            .Where(c => c.Cargo.CargoType == command)
            .Where(c => c.Tires.Any(t => t.TirePressure < 1));

        foreach (var car in fragileCars)
        {
            Console.WriteLine($"{car.Model}");
        }
    }
}

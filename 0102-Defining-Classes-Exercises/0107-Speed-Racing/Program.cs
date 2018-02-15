using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var cars = new List<Car>();

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var carInput = Console.ReadLine().Split();

            var car = new Car();
            car.Model = carInput[0];
            car.FuelAmount = double.Parse(carInput[1]);
            car.FuelPerKm = double.Parse(carInput[2]);

            cars.Add(car);
        }

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            var command = input.Split();
            var model = command[1];
            int amountKm = int.Parse(command[2]);

            var chosenCar = cars.FirstOrDefault(c => c.Model == model);

            if (chosenCar.EnoughtFuel(amountKm))
            {
                chosenCar.FuelAmount -= amountKm * chosenCar.FuelPerKm;
                chosenCar.Distance += amountKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.Distance}");
        }
    }
}

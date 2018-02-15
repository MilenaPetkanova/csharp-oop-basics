using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        var engines = new List<Engine>();
        var cars = new List<Car>();

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var engineInput = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var engine = new Engine(engineInput[0], engineInput[1]);

            if (engineInput.Length == 4)
            {
                engine.Displacement = engineInput[2];
                engine.Efficiency = engineInput[3];
            }
            else if (engineInput.Length == 3)
            {
                bool isDisplacement = int.TryParse(engineInput[2], out int weight);
                if (isDisplacement)
                {
                    engine.Displacement = engineInput[2];
                }
                else
                {
                    engine.Efficiency = engineInput[2];
                }
            }
            engines.Add(engine);
        }

        int m = int.Parse(Console.ReadLine());
        for (int i = 0; i < m; i++)
        {
            var carInput = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var carEngine = engines.FirstOrDefault(e => e.Model == carInput[1]);

            var car = new Car(carInput[0], carEngine);

            if (carInput.Length == 4)
            {
                car.Weight = carInput[2];
                car.Color = carInput[3];
            }
            else if (carInput.Length == 3)
            {
                bool isWeight = int.TryParse(carInput[2], out int weight);
                if (isWeight)
                {
                    car.Weight = carInput[2];
                }
                else
                {
                    car.Color = carInput[2];
                }
            }

            cars.Add(car);
        }

        foreach (var car in cars)
        {
            Console.WriteLine(car);
        }
    }
}

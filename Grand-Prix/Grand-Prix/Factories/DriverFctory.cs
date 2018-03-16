using System;
using System.Collections.Generic;
using System.Linq;

public static class DriverFactory
{
    public static Driver CreateDriver(List<string> args)
    {
        var type = args[0];
        var name = args[1];

        var hp = int.Parse(args[2]);
        var fuelAmount = double.Parse(args[3]);

        var tyreArgs = args.Skip(4).ToList();
        var tyre = TyreFactory.CreateTyre(tyreArgs);

        var car = new Car(hp, fuelAmount, tyre);

        switch (type)
        {
            case "Agressive":
                return new AggressiveDriver(name, car);
            case "Endurance":
                return new EnduranceDriver(name, car);
            default:
                throw new ArgumentException();
        }

    }
}
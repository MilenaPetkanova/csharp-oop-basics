using System;
using System.Collections.Generic;

public class BenderFactory
{
    public Bender CreateBender(List<string> args)
    {
        var type = args[0];
        var name = args[1];
        var power = int.Parse(args[2]);
        var secondaryParameter = args[3];

        switch (type)
        {
            case "Air":
                return new AirBender(name, power, double.Parse(secondaryParameter));
            case "Water":
                return new WaterBender(name, power, double.Parse(secondaryParameter));
            case "Fire":
                return new FireBender(name, power, double.Parse(secondaryParameter));
            case "Earth":
                return new EarthBender(name, power, int.Parse(secondaryParameter));
            default:
                throw new ArgumentException(ErrorMessages.InvalidType);
        }
    }
}


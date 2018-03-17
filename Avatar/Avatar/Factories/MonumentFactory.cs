using System;
using System.Collections.Generic;

public class MonumentFactory
{
    private Types types;

    public Monument CreateMonument(List<string> args)
    {
        var type = args[0];
        var name = args[1];
        var affinity = int.Parse(args[2]);

        switch (type)
        {
            case "Air":
                return new AirMonument(name, affinity);
            case "Water":
                return new WaterMonument(name, affinity);
            case "Fire":
                return new FireMonument(name, affinity);
            case "Earth":
                return new EarthMonument(name, affinity);
            default:
                throw new ArgumentException(ErrorMessages.InvalidType);
        }
    }
}
using System;
using System.Collections.Generic;

public static class TyreFactory
{
    public static Tyre CreateTyre(List<string> args)
    {
        var type = args[0];
        var hardness = double.Parse(args[1]);

        switch (type)
        {
            case "Ultrasoft":
                return new UltrasoftTyre(hardness, double.Parse(args[2]));
            case "Hard":
                return new HardTyre(hardness);
            default:
                throw new ArgumentException();
        }
    }
}
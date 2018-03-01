using System;

class Startup
{
    static void Main()
    {
        string driver = Console.ReadLine();
        string model = "488-Spider";
        IDrivable car = new Ferrari(model, driver);
        Console.WriteLine(car.ToString());
    }
}

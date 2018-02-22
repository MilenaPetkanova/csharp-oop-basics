using System;

class Startup
{
    static void Main()
    {
        double length = double.Parse(Console.ReadLine());
        double width = double.Parse(Console.ReadLine());
        double heigth = double.Parse(Console.ReadLine());

        var box = new Box(length, width, heigth);

        Console.WriteLine(box);
    }
}

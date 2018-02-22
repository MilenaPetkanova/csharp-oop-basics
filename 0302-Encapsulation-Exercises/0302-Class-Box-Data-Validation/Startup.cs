using System;

class Startup
{
    static void Main()
    {
        double length = double.Parse(Console.ReadLine());
        double width = double.Parse(Console.ReadLine());
        double heigth = double.Parse(Console.ReadLine());

        try
        {
            var box = new Box(length, width, heigth);
            Console.WriteLine(box);
        }
        catch (ArgumentException argEx)
        {
            Console.WriteLine(argEx.Message);
        }
        
    }
}

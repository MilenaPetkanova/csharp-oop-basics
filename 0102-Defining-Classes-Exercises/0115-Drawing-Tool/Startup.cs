using System;

class Startup
{
    static void Main()
    {
        var figureType = Console.ReadLine();

        switch (figureType)
        {
            case "Square":
                var square = new Square();
                square.FirstParam = int.Parse(Console.ReadLine());
                square.Draw();
                break;
            case "Rectangle":
                var rectangle = new Rectangle();
                rectangle.FirstParam = int.Parse(Console.ReadLine());
                rectangle.SecondParam = int.Parse(Console.ReadLine());
                rectangle.Draw();
                break;
            default:
                break;
        }
    }
}

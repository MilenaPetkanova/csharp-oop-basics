using System;
using System.Linq;

class StartUp
{
    static void Main()
    {
        var coords = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var rectangle = new Rectangle(coords[0], coords[1], coords[2], coords[3]);

        int pointCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < pointCount; i++)
        {
            var pointCoords = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var point = new Point(pointCoords[0], pointCoords[1]);
            var containsPoint = rectangle.ContainsPoint(point);
            Console.WriteLine(containsPoint);
        }
    }
}

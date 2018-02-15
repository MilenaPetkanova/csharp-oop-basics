using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var rectangles = new List<Rectangle>();

        var firstInput = Console.ReadLine().Split()
            .Select(int.Parse).ToArray();
        int n = firstInput[0];
        int m = firstInput[1];

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var rectangle = new Rectangle();

            rectangle.Id = input[0];
            rectangle.Width = double.Parse(input[1]);
            rectangle.Height = double.Parse(input[2]);
            rectangle.X = double.Parse(input[3]);
            rectangle.Y = double.Parse(input[4]);

            rectangles.Add(rectangle);
        }

        for (int i = 0; i < m; i++)
        {
            var pair = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var rectangle1 = rectangles.FirstOrDefault(r => r.Id == pair[0]);
            var rectangle2 = rectangles.FirstOrDefault(r => r.Id == pair[1]);

            bool intersect = rectangle1.IntersectsWith(rectangle2);

            PrintResult(intersect);
        }
    }

    private static void PrintResult(bool intersect)
    {
        if (intersect)
        {
            Console.WriteLine("true");
        }
        else
        {
            Console.WriteLine("false");
        }
    }
}

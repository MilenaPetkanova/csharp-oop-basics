using System;

class StartUp
{
    static void Main()
    {
        int figureSize = int.Parse(Console.ReadLine());
        for (int starCount = 1; starCount <= figureSize; starCount++)
        {
            PrintRow(figureSize, starCount);
        }
        for (int starCount = figureSize - 1; starCount >= 1; starCount--)
        {
            PrintRow(figureSize, starCount);
        }
    }

    static void PrintRow(int figureSize, int starCount)
    {
        for (int i = 0; i < figureSize - starCount; i++)
        {
            Console.Write(" ");
        }
        for (int col = 1; col < starCount; col++)
        {
            Console.Write("* ");
        }
        Console.WriteLine("*");
    }
}

using System;

class Startup
{
    static void Main()
    {
        var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        int hapiness = new FoodFactory().CalculateHappiness(input);
        string mood = new MoodFactory().GenerateMood(hapiness);

        Console.WriteLine(hapiness);
        Console.WriteLine(mood);
    }
}

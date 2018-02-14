using System;

class StartUp
{
    static void Main()
    {
        var firstDate = Console.ReadLine();
        var secondDate = Console.ReadLine();

        var dateDifference = new DateModifier();

        Console.WriteLine(dateDifference.CalculateDiff(firstDate, secondDate)); 
    }
}

using System;

class StartUp
{
    static void Main()
    {
        string command = Console.ReadLine();
        var priceCalculator = new PriceCalculator(command);
        Console.WriteLine(priceCalculator.CalculateHolidayPrice());
    }
}

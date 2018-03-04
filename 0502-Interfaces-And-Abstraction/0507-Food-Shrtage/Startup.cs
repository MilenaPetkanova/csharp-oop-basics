using System;
using System.Collections.Generic;
using System.Linq;

class Startup
{
    static void Main()
    {
        var foodBuyers = new List<IBuyer>();

        CollectBuyersInfo(foodBuyers);

        PeopleBuyFood(foodBuyers);

        int totalFoodAmount = foodBuyers.Sum(b => b.Food);
        Console.WriteLine(totalFoodAmount);
    }

    private static void PeopleBuyFood(List<IBuyer> foodBuyers)
    {
        string buyer = string.Empty;
        while ((buyer = Console.ReadLine()) != "End")
        {
            var foodBuyer = foodBuyers.FirstOrDefault(x => x.Name == buyer);

            if (foodBuyer != null)
            {
                foodBuyer.BuyFood();
            }
        }
    }

    private static void CollectBuyersInfo(List<IBuyer> foodBuyers)
    {
        var peopleCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < peopleCount; i++)
        {
            var infoArgs = Console.ReadLine().Split();
            if (infoArgs.Length == 4)
            {
                foodBuyers.Add(new Citizen(infoArgs[0], int.Parse(infoArgs[1]), infoArgs[2], infoArgs[3]));
            }
            else if (infoArgs.Length == 3)
            {
                foodBuyers.Add(new Rebel(infoArgs[0], int.Parse(infoArgs[1]), infoArgs[2]));
            }
        }
    }
}

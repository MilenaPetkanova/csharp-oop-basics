using System;
using System.Linq;

public class PriceCalculator
{
    public decimal Price { get; set; }
    public int Nights { get; set; }
    public Seasons Season { get; set; }
    public Discounts Discount { get; set; }

    public PriceCalculator(string command)
    {
        var commandArgs = command.Split().ToArray();
        this.Price = decimal.Parse(commandArgs[0]);
        this.Nights = int.Parse(commandArgs[1]);
        this.Season = Enum.Parse<Seasons>(commandArgs[2]);
        this.Discount = Discounts.None;
        if (commandArgs.Length == 4)
        {
            this.Discount = Enum.Parse<Discounts>(commandArgs[3]);
        }
    }

    public string CalculateHolidayPrice()
    {
        decimal finalPrice = this.Price * this.Nights * (decimal)this.Season;
        decimal discountPercentage = (decimal)(100 - this.Discount) / 100;
        finalPrice = discountPercentage * finalPrice;

        return finalPrice.ToString("F2");
    }
}
using System;

class Startup
{
    static void Main()
    {
        try
        {
            var name = Console.ReadLine().Split()[1];

            Dough dough = ReadDough();

            Pizza pizza = new Pizza(name, dough);

            ReadToppings(pizza);

            Console.WriteLine(pizza);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void ReadToppings(Pizza pizza)
    {
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            var toppingArgs = input.Split();
            var toppingType = toppingArgs[1];
            var toppingWeight = int.Parse(toppingArgs[2]);
            Topping topping = new Topping(toppingType, toppingWeight);
            pizza.AddTopping(topping);
        }
    }

    private static Dough ReadDough()
    {
        var doughArgs = Console.ReadLine().Split();
        var flourType = doughArgs[1];
        var bakingTechnique = doughArgs[2];
        var doughWeight = int.Parse(doughArgs[3]);
        Dough dough = new Dough(flourType, bakingTechnique, doughWeight);
        return dough;
    }
}

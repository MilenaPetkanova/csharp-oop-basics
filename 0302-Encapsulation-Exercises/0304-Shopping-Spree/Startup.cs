using System;
using System.Collections.Generic;
using System.Linq;

class Startup
{
    static void Main()
    {
        try
        {
            List<Person> allPeople = ReadPeople();

            List<Product> allProducts = ReadProducts();

            ProceedShopping(allPeople, allProducts);

            PrintShoppingResult(allPeople);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void PrintShoppingResult(List<Person> allPeople)
    {
        foreach (var person in allPeople)
        {
            Console.WriteLine(person);
        }
    }

    private static void ProceedShopping(List<Person> allPeople, List<Product> allProducts)
    {
        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            var commandArgs = command.Split();
            var personName = commandArgs[0];
            var productName = commandArgs[1];

            var person = allPeople.First(p => p.Name == personName);
            var product = allProducts.First(p => p.Name == productName);

            string commandOutput = person.BuyProduct(product);
            Console.WriteLine(commandOutput);
        }
    }

    private static List<Product> ReadProducts()
    {
        var allProducts = new List<Product>();
        var input = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var p in input)
        {
            var productArgs = p.Split('=');
            var name = productArgs[0];
            var cost = decimal.Parse(productArgs[1]);
            var product = new Product(name, cost);
            allProducts.Add(product);
        }
        return allProducts;
    }

    private static List<Person> ReadPeople()
    {
        var allPeople = new List<Person>();
        var input = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (var p in input)
        {
            var personArgs = p.Split('=');
            var name = personArgs[0];
            var money = decimal.Parse(personArgs[1]);
            var person = new Person(name, money);
            allPeople.Add(person);
        }
        return allPeople;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

class Startup
{
    static void Main()
    {
        var peopleInfo = new List<Person>();

        string inputLine;
        while ((inputLine = Console.ReadLine()) != "End")
        {
            var info = inputLine.Split();
            var name = info[0];

            if (!peopleInfo.Any(p => p.Name == name))
            {
                var person = new Person(name);
                GetPersonalInfo(info, person);
                peopleInfo.Add(person);
            }
            else
            {
                var person = peopleInfo.First(x => x.Name == name);
                GetPersonalInfo(info, person);
            }
        }

        var queryName = Console.ReadLine();

        PrintQueryPerson(peopleInfo, queryName);
    }

    private static void PrintQueryPerson(List<Person> people, string query)
    {
        var chosenPerson = people.First(p => p.Name == query);
        Console.WriteLine(chosenPerson.Name);
        Console.WriteLine("Company:");
        if (chosenPerson.TheCompany.Counter == 1)
        {
            Console.WriteLine($"{chosenPerson.TheCompany.Name} {chosenPerson.TheCompany.Department} {chosenPerson.TheCompany.Salary:f2}");
        }
        Console.WriteLine("Car:");
        if (chosenPerson.TheCar.Counter == 1)
        {
            Console.WriteLine($"{chosenPerson.TheCar.Model} {chosenPerson.TheCar.Speed}");
        }
        Console.WriteLine("Pokemon:");
        chosenPerson.Pokemons.ForEach(p => Console.WriteLine(string.Join(" ", p.Name, p.Type)));
        Console.WriteLine("Parents:");
        chosenPerson.Parents.ForEach(p => Console.WriteLine(string.Join(" ", p.Name, p.Birthday)));
        Console.WriteLine("Children:");
        chosenPerson.Children.ForEach(c => Console.WriteLine(string.Join(" ", c.Name, c.Birthday)));
    }

    private static void GetPersonalInfo(string[] info, Person person)
    {
        var infoType = info[1];

        switch (infoType)
        {
            case "company":
                person.TheCompany.Name = info[2];
                person.TheCompany.Department = info[3];
                person.TheCompany.Counter = 1;
                person.TheCompany.Salary = decimal.Parse(info[4]);
                break;
            case "car":
                person.TheCar.Model = info[2];
                person.TheCar.Speed = info[3];
                person.TheCar.Counter = 1;
                break;
            case "pokemon":
                var pokemon = new Person.Pokemon();
                pokemon.Name = info[2];
                pokemon.Type = info[3];
                person.Pokemons.Add(pokemon);
                break;
            case "parents":
                var parent = new Person.Parent();
                parent.Name = info[2];
                parent.Birthday = info[3];
                person.Parents.Add(parent);
                break;
            case "children":
                var child = new Person.Child();
                child.Name = info[2];
                child.Birthday = info[3];
                person.Children.Add(child);
                break;
            default:
                break;
        }
    }
}

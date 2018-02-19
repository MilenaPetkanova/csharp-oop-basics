using System;
using System.Collections.Generic;
using System.Linq;

class Startup
{
    // 60/100

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
        var chosenPerson = peopleInfo.First(p => p.Name == queryName);
        Console.WriteLine(chosenPerson);
    }

    private static void GetPersonalInfo(string[] info, Person person)
    {
        var infoType = info[1];

        switch (infoType)
        {
            case "company":
                person.TheCompany.CompanyName = info[2];
                person.TheCompany.Department = info[3];
                person.TheCompany.Counter = 1;
                person.TheCompany.Salary = decimal.Parse(info[4]);
                break;
            case "car":
                person.TheCar.CarModel = info[2];
                person.TheCar.CarSpeed = info[3];
                person.TheCar.Counter = 1;
                break;
            case "pokemon":
                var pokemon = new Person.Pokemon();
                pokemon.PokemonName = info[2];
                pokemon.PokemonType = info[3];
                person.Pokemons.Add(pokemon);
                break;
            case "parents":
                var parent = new Person.Parent();
                parent.ParentName = info[2];
                parent.ParentBirthday = info[3];
                person.Parents.Add(parent);
                break;
            case "children":
                var child = new Person.Child();
                child.ChildName = info[2];
                child.ChildBirthday = info[3];
                person.Children.Add(child);
                break;
            default:
                break;
        }
    }
}

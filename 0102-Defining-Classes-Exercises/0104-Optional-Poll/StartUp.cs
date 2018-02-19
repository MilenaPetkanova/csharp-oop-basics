using System;
using System.Collections.Generic;
using System.Linq;

class Startup
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        var people = new List<Person>();

        for (int i = 0; i < n; i++)
        {
            var line = Console.ReadLine().Split();
            var person = new Person()
            {
                Name = line[0],
                Age = int.Parse(line[1])
            };
            people.Add(person);
        }

        people.Where(p => p.Age > 30)
            .OrderBy(p => p.Name)
            .ToList()
            .ForEach(p => Console.WriteLine($"{p.Name} - {p.Age}"));
    }
}

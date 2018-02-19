using System;
using System.Collections.Generic;
using System.Linq;

class Startup
{
    static void Main()
    {
        var familyTree = new List<Person>();
        var familyRelations = new List<string>();

        var query = Console.ReadLine();

        string line;
        while ((line = Console.ReadLine()) != "End")
        {
            if (!line.Contains('-'))
            {
                var personInfo = line.Split();
                var name = personInfo[0] + " " + personInfo[1];
                var birthdate = personInfo[2];
                familyTree.Add(new Person(name, birthdate));
            }
            else
            {
                familyRelations.Add(line);
            }
        }

        foreach (var relation in familyRelations)
        {
            var personInfo = relation.Split('-').Select(x => x.Trim()).ToArray();
            var parentParam = personInfo[0];
            var childParam = personInfo[1];

            var parent = new Person();
            var child = new Person();

            parent = AddParentAndChildInfo(parentParam, familyTree, parent);
            child = AddParentAndChildInfo(childParam, familyTree, child);

            child.Parents.Add(parent);
            parent.Children.Add(child);
        }

        PrintQueryPerson(familyTree, query);

    }

    private static void PrintQueryPerson(List<Person> familyTree, string query)
    {
        Person queryPerson;
        if (IsBirthday(query))
        {
            queryPerson = familyTree.FirstOrDefault(p => p.BirthDate == query);
        }
        else
        {
            queryPerson = familyTree.FirstOrDefault(p => p.Name == query);
        }
        Console.WriteLine(queryPerson);
    }

    private static Person AddParentAndChildInfo(string personInfo, List<Person> famillyTree, Person person)
    {
        if (IsBirthday(personInfo))
        {
            person = famillyTree.FirstOrDefault(p => p.BirthDate == personInfo);
        }
        else
        {
            person = famillyTree.FirstOrDefault(p => p.Name == personInfo);
        }
        return person;
    }

    static bool IsBirthday(string input)
    {
        return Char.IsDigit(input[0]);
    }
}

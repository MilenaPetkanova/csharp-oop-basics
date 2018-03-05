using System;

class Startup
{
    static void Main()
    {
        string command = string.Empty;
        while ((command = Console.ReadLine()) != "End")
        {
            var info = command.Split();
            var name = info[0];
            var country = info[1];
            var age = int.Parse(info[2]);

            IResident resident = new Citizen(name, country, age);
            IPerson person = new Citizen(name, country, age);

            Console.WriteLine(resident.GetName());
            Console.WriteLine(person.GetName());
        }
    }
}

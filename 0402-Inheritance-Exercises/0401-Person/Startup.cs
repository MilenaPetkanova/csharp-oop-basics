using System;

class Startup
{
    static void Main()
    {
        string name = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());

        try
        {
            var child = new Child(name, age);
            Console.WriteLine(child);
        }
        catch (ArgumentException ea)
        {
            Console.WriteLine(ea.Message);
        }
    }
}

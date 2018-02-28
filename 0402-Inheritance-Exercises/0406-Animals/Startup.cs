using System;
using System.Collections.Generic;

class Startup
{
    static void Main()
    {
        var animals = new List<Animal>();

        var animalType = string.Empty;
        while ((animalType = Console.ReadLine().Trim()) != "Beast!")
        {
            try
            {
                ReadAndAddAnimals(animals, animalType);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        foreach (var animal in animals)
        {
            Console.WriteLine(animal.GetType().Name);
            Console.WriteLine($"{animal.Name} {animal.Age} {animal.Gender}");
            Console.WriteLine(animal.ProduceSound());
        }
    }

    private static void ReadAndAddAnimals(List<Animal> animals, string animalType)
    {
        var animalArgs = Console.ReadLine().Split();
        var name = animalArgs[0];
        var age = int.Parse(animalArgs[1]);
        var gender = string.Empty;
        if (animalArgs.Length == 3)
        {
            gender = animalArgs[2];
        }

        switch (animalType)
        {
            case "Dog":
                animals.Add(new Dog(name, age, gender));
                break;
            case "Frog":
                animals.Add(new Frog(name, age, gender));
                break;
            case "Cat":
                animals.Add(new Cat(name, age, gender));
                break;
            case "Kitten":
                animals.Add(new Kitten(name, age, "Female"));
                break;
            case "Tomcat":
                animals.Add(new Tomcat(name, age, "Male"));
                break;
            default:
                throw new ArgumentException("Invalid input!");
        }
    }
}

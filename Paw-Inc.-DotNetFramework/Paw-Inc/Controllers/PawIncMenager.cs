using System;
using System.Collections.Generic;
using System.Linq;

public class PawIncMenager : IPawIncMenager
{
    public PawIncMenager()
    {
        this.CleansingCenters = new List<CleansingCenter>();
        this.AdoptionCenters = new List<AdoptionCenter>();
        this.AdoptedAnimals = new List<IAnimal>();
    }

    public List<CleansingCenter> CleansingCenters { get; private set; }

    public List<AdoptionCenter> AdoptionCenters { get; private set; }

    public List<IAnimal> AdoptedAnimals { get; private set; }

    public void RegisterCleansingCenter(string name)
    {
        this.CleansingCenters.Add(new CleansingCenter(name));
    }

    public void RegisterAdoptionCenter(string name)
    {
        this.AdoptionCenters.Add(new AdoptionCenter(name));
    }

    public void RegisterDog(string name, int age, int learnedCommands, string adoptionCenterName)
    {
        Animal dog = new Dog(name, age, learnedCommands);

        var adoptionCenter = this.AdoptionCenters.First(c => c.Name == adoptionCenterName);
        adoptionCenter.StoredAnimals.Add(dog);
    }

    public void RegisterCat(string name, int age, int intelligenceCoefficient, string adoptionCenterName)
    {
        Animal cat = new Cat(name, age, intelligenceCoefficient);

        var adoptionCenter = this.AdoptionCenters.First(c => c.Name == adoptionCenterName);
        adoptionCenter.StoredAnimals.Add(cat);
    }

    public void SendForCleansing(string adoptionCenterName, string cleansingCenterName)
    {
        var adoptionCenter = this.AdoptionCenters.Find(c => c.Name == adoptionCenterName);
        var cleansingCenter = this.CleansingCenters.Find(c => c.Name == cleansingCenterName);

        var uncleansedAnimals = adoptionCenter.SendCleansing();

        cleansingCenter.StoredAnimals.AddRange(uncleansedAnimals);
    }

    public void Cleanse(string cleansingCenterName)
    {
        var cleansingCenter = this.CleansingCenters.Find(c => c.Name == cleansingCenterName);

        cleansingCenter.CleanseAllAnimals();
    }

    public void Adopt(string adoptionCenterName)
    {
        var adoptionCenter = this.AdoptionCenters.First(c => c.Name == adoptionCenterName);

        var adoptedAnimals = adoptionCenter.AdoptCleansed().ToList();

        this.AdoptedAnimals.AddRange(adoptedAnimals);
    }

    public void Report()
    {
        Console.WriteLine("Paw Incorporative Regular Statistics");
        Console.WriteLine($"Adoption Centers: {this.AdoptionCenters.Count}");
        Console.WriteLine($"Cleansing Centers: {this.CleansingCenters.Count}");

        var adoptedAnimalsNames = this.AdoptedAnimals
            .OrderBy(a => a.Name).Select(a => a.Name).ToList();
        if (adoptedAnimalsNames.Count == 0)
        {
            Console.WriteLine("Adopted Animals: None");
        }
        else
        {
            Console.WriteLine("Adopted Animals: " + String.Join(", ", adoptedAnimalsNames));
        }

        var allCleansedAnimalsNames = GetAllCleansedAnimalsNames();
        if (adoptedAnimalsNames.Count == 0)
        {
            Console.WriteLine("Cleansed Animals: None");
        }
        else
        {
            allCleansedAnimalsNames.Sort();
            Console.WriteLine("Cleansed Animals: " + String.Join(", ", allCleansedAnimalsNames));
        }

        int amountOfAnimalsWaitingForAdoption = CountAnimalsWaitingForAdoption();
        Console.WriteLine($"Animals Awaiting Adoption: {amountOfAnimalsWaitingForAdoption}");

        int amountOfAnimalsWaitingForCleansing = CountAnimalsWaitingForCleansing();
        Console.WriteLine($"Animals Awaiting Cleansing: {amountOfAnimalsWaitingForCleansing}");

    }

    private int CountAnimalsWaitingForCleansing()
    {
        var counter = 0;
        foreach (var center in this.CleansingCenters)
        {
            foreach (var animal in center.StoredAnimals)
            {
                if (animal.CleansingStatus == "UNCLEANSED")
                {
                    counter++;
                }
            }
        }
        return counter;
    }

    private int CountAnimalsWaitingForAdoption()
    {
        var counter = 0;
        foreach (var center in this.AdoptionCenters)
        {
            foreach (var animal in center.StoredAnimals)
            {
                if (animal.CleansingStatus == "CLEANSED")
                {
                    counter++;
                }
            }
        }
        return counter;
    }

    private List<string> GetAllCleansedAnimalsNames()
    {
        var allCleansedAnimalsNames = new List<string>();

        allCleansedAnimalsNames.AddRange(this.AdoptedAnimals.Select(a => a.Name));

        foreach (var center in this.AdoptionCenters)
        {
            foreach (var animal in center.StoredAnimals)
            {
                if (animal.CleansingStatus == "CLEANSED")
                {
                    allCleansedAnimalsNames.Add(animal.Name);
                }
            }
        }

        return allCleansedAnimalsNames;
    }
}

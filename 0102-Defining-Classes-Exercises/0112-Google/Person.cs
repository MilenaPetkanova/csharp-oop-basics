using System.Collections.Generic;
using System.Text;

public class Person
{
    public string Name { get; set; }
    public Car TheCar { get; set; }
    public Company TheCompany { get; set; }
    public List<Pokemon> Pokemons { get; set; }
    public List<Parent> Parents { get; set; }
    public List<Child> Children { get; set; }

    public Person(string name)
    {
        this.Name = name;
        this.TheCar = new Car();
        this.TheCompany = new Company();
        this.Pokemons = new List<Pokemon>();
        this.Parents = new List<Parent>();
        this.Children = new List<Child>();
    }

    public class Company
    {
        public string CompanyName { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
        public int Counter { get; set; }
    }

    public class Car
    {
        public string CarModel { get; set; }
        public string CarSpeed { get; set; }
        public int Counter { get; set; }
    }

    public class Pokemon
    {
        public string PokemonName { get; set; }
        public string  PokemonType { get; set; }
    }

    public class Parent
    {
        public string ParentName { get; set; }
        public string ParentBirthday { get; set; }
    }

    public class Child
    {
        public string ChildName { get; set; }
        public string ChildBirthday { get; set; }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"{this.Name}");

        sb.AppendLine("Company:");
        if (this.TheCompany.Counter != 0)
        {
            sb.AppendLine($"{this.TheCompany.CompanyName} {this.TheCompany.Department} {this.TheCompany.Salary:#.##}");
        }

        sb.AppendLine("Car:");
        if (this.TheCar.Counter != 0)
        {
            sb.AppendLine($"{this.TheCar.CarModel} {this.TheCar.CarSpeed}");
        }

        sb.AppendLine("Pokemon:");
        foreach (var pokemon in this.Pokemons)
        {
            sb.AppendLine($"{pokemon.PokemonName} {pokemon.PokemonType}");
        }

        sb.AppendLine("Parents:");
        foreach (var parent in this.Parents)
        {
            sb.AppendLine($"{parent.ParentName} {parent.ParentBirthday}");
        }

        sb.AppendLine("Children:");
        foreach (var child in this.Children)
        {
            sb.AppendLine($"{child.ChildName} {child.ChildBirthday}");
        }

        return sb.ToString();
    }
}
public abstract class Animal : IAnimal
{
    protected Animal(string name, int age)
    {
        this.Name = name;
        this.Age = age;
        this.CleansingStatus = "UNCLEANSED";
    }

    public string Name { get; private set; }

    public int Age { get; private set; }

    public string CleansingStatus { get; internal set; }
}

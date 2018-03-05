public class Citizen : IPerson, IResident
{
    private string name;
    private string country;
    private int age;

    public Citizen(string name, string country, int age) 
    {
        this.Name = name;
        this.Age = age;
        this.Country = country; 
    }
    
    public string Name { get; private set; }

    public string Country { get; private set; }

    public int Age { get; private set; }

    string IResident.GetName()
    {
        return this.Name;
    }

    string IPerson.GetName()
    {
        return "Mr/Ms/Mrs " + this.Name;
    }
}
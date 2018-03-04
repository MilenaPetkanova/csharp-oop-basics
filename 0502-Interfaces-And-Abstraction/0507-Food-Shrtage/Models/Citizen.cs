public class Citizen : IBuyer, IIdentible, IBorn
{
    public Citizen(string name, int age, string id, string birthDate)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.BirthDate = birthDate;
    }

    public string Name { get; private set; }

    public int Age { get; private set; }

    public string Id { get; private set; }

    public string BirthDate { get; private set; }

    public int Food { get; private set; }

    public void BuyFood()
    {
        this.Food += 10;
    }
}
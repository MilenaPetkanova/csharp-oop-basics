public class Person
{
    private string firstName;
    private string lastName;
    private int age;

    public string FirstName => this.firstName;
    public string LastName => this.lastName;
    public int Age => this.age;

    public Person(string firstName, string secondName, int age)
    {
        this.firstName = firstName;
        this.lastName = secondName;
        this.age = age;
    }

    public override string ToString()
    {
        return $"{this.firstName} {this.lastName} is {this.age} years old.".ToString();
    }
}

public class Person
{
    private string firstName;
    private string lastName;
    private int age;
    private decimal salary;

    public string FirstName => this.firstName;
    public string LastName => this.lastName;
    public int Age => this.age;
    public decimal Salary => this.salary;

    public Person(string firstName, string secondName, int age, decimal salary)
    {
        this.firstName = firstName;
        this.lastName = secondName;
        this.age = age;
        this.salary = salary;
    }

    public void IncreaseSalary(decimal percentage)
    {
        var increasement = this.salary * percentage / 100;
        if (this.Age >= 30)
        {
            this.salary += increasement;
        }
        else
        {
            this.salary += increasement / 2;
        }
    }

    public override string ToString()
    {
        return $"{this.firstName} {this.lastName} receives {this.salary:F2} leva.".ToString();
    }
}

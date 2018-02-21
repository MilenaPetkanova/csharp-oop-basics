using System;

public class Person
{
    const int MIN_NAME_LENGTH = 3;
    const decimal MIN_SALARY = 460;
    private string firstName;
    private string lastName;
    private int age;
    private decimal salary;

    public Person(string firstName, string secondName, int age, decimal salary)
    {
        this.FirstName = firstName;
        this.LastName = secondName;
        this.Age = age;
        this.Salary = salary;
    }

    public string FirstName
    {
        get { return this.firstName; }
        set
        {
            if (value?.Length < MIN_NAME_LENGTH)
            {
                throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
            }
            this.firstName = value;
        }
    }

    public string LastName
    {
        get { return this.lastName; }
        set
        {
            if (value?.Length < MIN_NAME_LENGTH)
            {
                throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
            }
            this.lastName = value;
        }
    }
    public int Age
    {
        get { return this.age; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Age cannot be zero or a negative integer!");
            }
            this.age = value;
        }
    }

    public decimal Salary
    {
        get { return this.salary; }
        set
        {
            if (value < MIN_SALARY)
            {
                throw new ArgumentException("Salary cannot be less than 460 leva!");
            }
            this.salary = value;
        }
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

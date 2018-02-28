using System;

public abstract class Animal : ISoundProducable
{
    private const string ErrorMessage = "Invalid input!";

    protected string name;
    protected int age;
    protected string gender;

    public Animal(string name, int age, string gender)
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender;
    }

    public string Name
    {
        get { return name; }
        private set
        {
            NotEmptyValidation(value);
            name = value;
        }
    }

    public int Age
    {
        get { return age; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(ErrorMessage);
            }
            NotEmptyValidation(value.ToString());
            age = value;
        }
    }

    public string Gender
    {
        get { return gender; }
        private set
        {
            NotEmptyValidation(value);
            gender = value;
        }
    }

    private static void NotEmptyValidation(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException(ErrorMessage);
        }
    }

    public virtual string ProduceSound()
    {
        return string.Empty;
    }
}
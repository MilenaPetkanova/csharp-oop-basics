using System;

public class Human
{
    private const int FIRST_NAME_MIN_LENGTH = 4;
    private const int LAST_NAME_MIN_LENGTH = 3;

    private string firstName;
    private string secondName;

    public Human(string firstName, string secondName)
    {
        this.FirstName = firstName;
        this.SecondName = secondName;
    }

    public string FirstName
    {
        get { return firstName; }
        protected set
        {
            if (char.IsLower(value[0]))
            {
                throw new ArgumentException("Expected upper case letter! Argument: firstName");
            }
            else if (value.Length < FIRST_NAME_MIN_LENGTH)
            {
                throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
            }
            firstName = value;
        }
    }

    public string SecondName
    {
        get { return secondName; }
        protected set
        {
            if (char.IsLower(value[0]))
            {
                throw new ArgumentException("Expected upper case letter! Argument: lastName");
            }
            else if (value.Length < LAST_NAME_MIN_LENGTH)
            {
                throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName ");
            }
            secondName = value;
        }
    }

    public override string ToString()
    {
        return $"First Name: {this.firstName}" + Environment.NewLine 
            + $"Last Name: {this.secondName}";
    }
}
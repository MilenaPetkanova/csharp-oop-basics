using System;
using System.Linq;
using System.Text.RegularExpressions;

public abstract class Bender
{
    private const string NAME_VALIDATION = @"^[a-zA-Z0-9]*$";
    private string name;
    private int power;

    protected Bender(string name, int power)
    {
        this.Name = name;
        this.Power = power;
    }

    public int Power
    {
        get { return power; }
        protected set { power = value; }
    }

    public string Name
    {
        get { return name; }
        protected set
        {
            if (!Regex.IsMatch(value, NAME_VALIDATION))
            {
                throw new ArgumentException(ErrorMessages.InvalidName);
            }
            name = value;
        }
    }

    public override string ToString()
    {
        return $"{this.name}, Power: {this.power}, ";
    }

}



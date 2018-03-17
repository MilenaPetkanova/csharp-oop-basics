using System;
using System.Text.RegularExpressions;

public abstract class Monument
{
    private const string NAME_VALIDATION = @"^[a-zA-Z0-9]*$";
    private string name;

    protected Monument(string name)
    {
        this.Name = name;
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

    public virtual int Affinity { get; protected set; }

    public override string ToString()
    {
        return $"Monument: {this.Name}, ";
    }
}


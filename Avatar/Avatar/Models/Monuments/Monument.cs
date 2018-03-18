using System;
using System.Text.RegularExpressions;

public abstract class Monument
{
    private string name;

    protected Monument(string name)
    {
        this.Name = name;
    }

    public string Name
    {
        get { return name; }
        protected set { name = value; }
    }

    public abstract int GetAffinity();

    public override string ToString()
    {
        return $"Monument: {this.Name}, ";
    }
}


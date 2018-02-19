using System.Collections.Generic;
using System.Text;

public class Person
{
    public string Name { get; set; }
    public string BirthDate { get; set; }
    public List<Person> Parents { get; set; }
    public List<Person> Children { get; set; }

    public Person()
    {
        this.Parents = new List<Person>();
        this.Children = new List<Person>();
    }

    public Person(string name, string birthDate) : this()
    {
        this.Name = name;
        this.BirthDate = birthDate;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(this.Name + " " + this.BirthDate);
        sb.AppendLine("Parents:");
        foreach (var parent in this.Parents)
        {
            sb.AppendLine(parent.Name + " " + parent.BirthDate);
        }
        sb.AppendLine("Children:");
        foreach (var child in this.Children)
        {
            sb.AppendLine(child.Name + " " + child.BirthDate);
        }
        return sb.ToString();
    }

}
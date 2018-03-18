using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Nation
{
    private List<Bender> allBenders;
    private List<Monument> allMonuments;
    
    public Nation(string type)
    {
        this.AllBenders = new List<Bender>();
        this.AllMonuments = new List<Monument>();
        this.Type = type;
    }

    public List<Bender> AllBenders
    {
        get => this.allBenders;
        private set => this.allBenders = value;
    }

    public List<Monument> AllMonuments
    {
        get => this.allMonuments;
        private set => this.allMonuments = value;
    }

    public string Type { get; set; }

    public int TotalPower { get; private set; }

    internal void AssignBender(Bender bender)
    {
        this.allBenders.Add(bender);
    }

    internal void AssignMonument(Monument monument)
    {
        this.allMonuments.Add(monument);
    }

    public void CalculateTotalPower()
    {
        int monumentsTotalPower = this.allMonuments.Sum(m => m.GetAffinity());

        this.TotalPower += this.allBenders.Sum(b => b.Power);
        this.TotalPower += (this.TotalPower / 100) * monumentsTotalPower;
    }

    internal void DeleteAll()
    {
        this.AllBenders = new List<Bender>();
        this.AllMonuments = new List<Monument>();
    }

    public override string ToString()
    {
        var output = new StringBuilder();
        output.AppendLine($"{this.Type} Nation");

        if (this.allBenders.Count == 0)
        {
            output.AppendLine("Benders: None");
        }
        else
        {
            output.AppendLine("Benders:");
            foreach (var bender in allBenders)
            {
                output.AppendLine($"###{bender.ToString()}");
            }
        }

        if (this.allMonuments.Count == 0)
        {
            output.AppendLine("Monuments: None");
        }
        else
        {
            output.AppendLine("Monuments:");
            foreach (var monument in this.allMonuments)
            {
                output.AppendLine($"###{monument.ToString()}");
            }
        }

        return output.ToString().TrimEnd();
    }
}


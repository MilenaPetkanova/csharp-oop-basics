using System.Collections.Generic;
using System.Text;

public class Engineer : SpecialisedSoldier, IEngineer
{
    public Engineer(string id, string firstName, string lastName, decimal salary, string corps, List<Repair> repairs) 
        : base(id, firstName, lastName, salary, corps)
    {
        this.Repairs = repairs;
    }

    public List<Repair> Repairs { get; private set; }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        sb.Append("Repairs:");
        foreach (var repair in this.Repairs)
        {
            sb.Append("\n  " + repair.ToString());
        }
        return sb.ToString(); 
    }
}


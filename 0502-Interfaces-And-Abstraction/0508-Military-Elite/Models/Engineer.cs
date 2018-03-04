using System.Collections.Generic;
using System.Text;

public class Engineer : SpecialisedSoldier, IEngineer
{
    private List<Repair> repairs;

    public Engineer(string id, string firstName, string lastName, decimal salary, string corps, List<Repair> repairs) 
        : base(id, firstName, lastName, salary, corps)
    {
        this.Repairs = repairs;
    }

    public List<Repair> Repairs
    {
        get => this.repairs;
        private set => this.repairs = value;
    }

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


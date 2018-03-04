using System.Collections.Generic;
using System.Text;

public class LeutenantGeneral : Private, ILeutenantGeneral
{
    public LeutenantGeneral(string id, string firstName, string lastName, decimal salary, List<Private> privates)
        : base(id, firstName, lastName, salary)
    {
        this.Privates = privates;
    }

    public List<Private> Privates { get; private set; }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        sb.AppendLine("Privates:");
        foreach (var privateSoldier in this.Privates)
        {
            sb.AppendLine("  " + privateSoldier.ToString());
        }
        return sb.ToString().Trim();
    }
}
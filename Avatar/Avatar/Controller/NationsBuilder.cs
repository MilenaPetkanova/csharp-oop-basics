using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NationsBuilder
{
    private Nation nation;
    private List<Nation> allNations;
    private BenderFactory benderFactory;
    private MonumentFactory monumentFactory;
    private List<Nation> wars;

    public NationsBuilder()
    {
        this.allNations = new List<Nation>();
        this.benderFactory = new BenderFactory();
        this.monumentFactory = new MonumentFactory();
        this.wars = new List<Nation>();
    }

    public void AssignBender(List<string> benderArgs)
    {
        nation = allNations.FirstOrDefault(n => n.Type == benderArgs[0]);

        if (nation == null)
        {
            nation = new Nation(benderArgs[0]);
            this.allNations.Add(nation);
        }

        nation.AssignBender(benderFactory.CreateBender(benderArgs));
       
    }
    public void AssignMonument(List<string> monumentArgs)
    {
        nation = allNations.FirstOrDefault(n => n.Type == monumentArgs[0]);

        if (nation == null)
        {
            nation = new Nation(monumentArgs[0]);
            this.allNations.Add(nation);
        }

        nation.AssignMonument(monumentFactory.CreateMonument(monumentArgs));
    }

    public string GetStatus(string nationsType)
    {
        nation = allNations.First(n => n.Type == nationsType);

        return nation.ToString();
    }
    public void IssueWar(string nationsType)
    {
        var nationIssuedWar = allNations
            .First(n => n.Type == nationsType);

        wars.Add(nationIssuedWar);

        this.allNations.ForEach(n => n.CalculateTotalPower());

        var winner = this.allNations.First();

        foreach (var nation in this.allNations)
        {
            if (nation.TotalPower > winner.TotalPower)
            {
                winner = nation;
            }
        }

        var loosers = this.allNations
            .Where(n => n.Type != winner.Type)
            .ToArray();

        foreach (var looserNation in loosers)
        {
            looserNation.DeleteAll();
        }
        
    }
    public string GetWarsRecord()
    {
        var output = new StringBuilder();

        for (int i = 1; i <= this.wars.Count; i++)
        {
            output.AppendLine($"War {i} issued by {wars[i - 1].Type}");
        }

        return output.ToString().TrimEnd();
    }

}
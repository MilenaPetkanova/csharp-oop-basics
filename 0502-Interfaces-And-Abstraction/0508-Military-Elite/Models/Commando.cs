using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Commando : SpecialisedSoldier, ICommando
{
    private List<Mission> missions;

    public Commando(string id, string firstName, string lastName, decimal salary, string corps, List<Mission> missions) 
        : base(id, firstName, lastName, salary, corps)
    {
        this.Missions = missions;
    }

    public List<Mission> Missions
    {
        get => this.missions;
        private set
        {
            this.missions = value;
            CompleteMission(this.missions);
        }
    }

    public void CompleteMission(List<Mission> missions)
    {
        var invalidMission = missions.FirstOrDefault(m => m.State != "inProgress" && m.State != "Finished");
        while (invalidMission != null)
        {
            this.missions.Remove(invalidMission);
            invalidMission = missions.FirstOrDefault(m => m.State != "inProgress" && m.State != "Finished");
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(base.ToString());
        sb.AppendLine("Missions:");
        foreach (var mission in this.missions)
        {
            sb.AppendLine("  " + mission.ToString());
        }
        return sb.ToString().Trim();
    }
}

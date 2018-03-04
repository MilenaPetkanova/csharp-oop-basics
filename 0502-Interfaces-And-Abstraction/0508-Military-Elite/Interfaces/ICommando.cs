using System.Collections.Generic;

public interface ICommando 
{
    List<Mission> Missions { get; }

    void CompleteMission(List<Mission> missions);
}
using System;
using System.Collections.Generic;
using System.Linq;

class Startup
{
    static void Main()
    {
        var soldiers = new List<Soldier>();
        var privates = new List<Private>();

        string inputLine = string.Empty;
        while ((inputLine = Console.ReadLine()) != "End")
        {
            var info = inputLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var soldierType = info[0];
            var id = info[1];
            var firstName = info[2];
            var lastName = info[3];
            decimal salary = decimal.Parse(info[4]);
            string corps;

            switch (soldierType)
            {
                case "Private":
                    var privateSoldier = new Private(id, firstName, lastName, salary);
                    privates.Add(privateSoldier);
                    soldiers.Add(privateSoldier);
                    break;
                case "LeutenantGeneral":
                    var privatesOfLeutenantGeneral = GetPrivatesOFLeutenantGeneral(privates, info);
                    soldiers.Add(new LeutenantGeneral(id, firstName, lastName, salary, privatesOfLeutenantGeneral));
                    break;
                case "Engineer":
                    corps = info[5];
                    var repairs = GetRepairs(info);
                    var engineer = new Engineer(id, firstName, lastName, salary, corps, repairs);
                    if (engineer.Corps == null)
                    {
                        continue;
                    }
                    soldiers.Add(engineer);
                    break;
                case "Commando":
                    corps = info[5];
                    var missions = GetMissions(info);
                    var commando = new Commando(id, firstName, lastName, salary, corps, missions);
                    if (commando.Corps == null)
                    {
                        continue;
                    }
                    soldiers.Add(commando);
                    break;
                case "Spy":
                    int codeNumber = int.Parse(info[4]);
                    soldiers.Add(new Spy(id, firstName, lastName, codeNumber));
                    break;
                default:
                    break;
            }
        }
        foreach (var soldier in soldiers)
        {
            Console.WriteLine(soldier.ToString());
        }
    }

    private static List<Mission> GetMissions(string[] info)
    {
        var missions = new List<Mission>();
        for (int i = 6; i < info.Length - 1; i += 2)
        {
            var missionCodeName = info[i];
            var missionState = info[i + 1];
            missions.Add(new Mission(missionCodeName, missionState));
        }
        return missions;
    }

    private static List<Repair> GetRepairs(string[] info)
    {
        var repairs = new List<Repair>();
        for (int i = 6; i < info.Length; i += 2)
        {
            var repaitPart = info[i];
            int repairHours = int.Parse(info[i + 1]);
            repairs.Add(new Repair(repaitPart, repairHours));
        }
        return repairs;
    }

    private static List<Private> GetPrivatesOFLeutenantGeneral(List<Private> privates, string[] info)
    {
        var privatesOfLeutenantGeneral = new List<Private>();
        for (int i = 4; i < info.Length; i++)
        {
            var privateId = info[i];
            if (privates.Any(x => x.Id == privateId))
            {
                privatesOfLeutenantGeneral.Add(privates.First(x => x.Id == privateId));
            }
        }
        return privatesOfLeutenantGeneral;
    }
}

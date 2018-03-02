using System;
using System.Collections.Generic;
using System.Linq;

class Startup
{
    static void Main()
    {
        var bornCreatures = new List<IBorn>();

        string info = string.Empty;
        while ((info = Console.ReadLine()) != "End")
        {
            var infoArgs = info.Split();
            if (infoArgs[0] == "Citizen")
            {
                bornCreatures.Add(new Citizen(infoArgs[1], int.Parse(infoArgs[2]), infoArgs[3], infoArgs[4]));
            }
            else if (infoArgs[0] == "Pet")
            {
                bornCreatures.Add(new Pet(infoArgs[1], infoArgs[2]));
            }
        }

        string appliedYear = Console.ReadLine();

        var bornInAppliedYear = bornCreatures
            .Where(x => x.BirthDate.Split('/').Last() == appliedYear); 

        foreach (var bornCreature in bornInAppliedYear)
        {
            Console.WriteLine(bornCreature.BirthDate);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

class Startup
{
    static void Main()
    {
        var society = new List<IIdentible>();

        string info = string.Empty;
        while ((info = Console.ReadLine()) != "End")
        {
            var infoArgs = info.Split();
            if (infoArgs.Length == 3)
            {
                society.Add(new Citizen(infoArgs[0], int.Parse(infoArgs[1]), infoArgs[2]));
            }
            else if (infoArgs.Length == 2)
            {
                society.Add(new Robot(infoArgs[0], infoArgs[1]));
            }
        }

        string fakeIdPattern = Console.ReadLine();

        var fakeIndividuals = society.Where(x => x.Id.EndsWith(fakeIdPattern));

        foreach (var fakeIndividual in fakeIndividuals)
        {
            Console.WriteLine(fakeIndividual.Id);
        }
    }
}

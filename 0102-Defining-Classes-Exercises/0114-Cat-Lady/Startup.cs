using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class Startup
{
    static void Main()
    {
        List<Cat> cats = new List<Cat>();

        string inputLine;
        while ((inputLine = Console.ReadLine()) != "End")
        {
            var catInfo = inputLine.Split();
            var catType = catInfo[0];
            var catName = catInfo[1];
            var catParam = catInfo[2];

            switch (catType)
            {
                case "Siamese":
                    var siamese = new Siamese()
                    {
                        Name = catName,
                        EarSize = int.Parse(catParam)
                    };
                    cats.Add(siamese);
                    break;
                case "Cymric":
                    var cymric = new Cymric()
                    {
                        Name = catName,
                        FurLength = double.Parse(catParam)
                    };
                    cats.Add(cymric);
                    break;
                case "StreetExtraordinaire":
                    var streetExtraordinaire = new StreetExtraordinaire()
                    {
                        Name = catName,
                        DecibelsOfMeows = int.Parse(catParam)
                    };
                    cats.Add(streetExtraordinaire);
                    break;
                default:
                    break;
            }
        }

        var queryCat = Console.ReadLine();
        var chosenCat = cats.First(c => c.Name == queryCat);
        Console.WriteLine(chosenCat);
    }
}

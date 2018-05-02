using System.Collections.Generic;
using System.Linq;

public class AdoptionCenter : Center
{
    public AdoptionCenter(string name) 
        : base(name)
    {
    }

    public IList<IAnimal> SendCleansing()
    {
        var uncleansedAnimals = base.StoredAnimals.Where(a => a.CleansingStatus == "UNCLEANSED").ToList();
        return uncleansedAnimals;
    }
    
    public IList<IAnimal> AdoptCleansed()
    {
        var cleansedAnimals = base.StoredAnimals.Where(a => a.CleansingStatus == "CLEANSED").ToList();

        base.StoredAnimals.RemoveAll(a => a.CleansingStatus == "CLEANSED");

        return cleansedAnimals;
    }
}
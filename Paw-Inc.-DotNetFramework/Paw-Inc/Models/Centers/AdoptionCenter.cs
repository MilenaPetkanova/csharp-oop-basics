using System.Collections.Generic;
using System.Linq;

public class AdoptionCenter : Center
{
    public AdoptionCenter(string name) 
        : base(name)
    {
    }

    public IEnumerable<Animal> SendCleansing()
    {
        var uncleansedAnimals = base.StoredAnimals.Where(a => a.CleansingStatus == "UNCLEANSED");
        return uncleansedAnimals;
    }
    
    public List<Animal> AdoptCleansedAnimals()
    {
        var cleansedAnimals = base.StoredAnimals.Where(a => a.CleansingStatus == "CLEANSED").ToList();

        base.StoredAnimals.RemoveAll(a => a.CleansingStatus == "CLEANSED");

        return cleansedAnimals;
    }
}
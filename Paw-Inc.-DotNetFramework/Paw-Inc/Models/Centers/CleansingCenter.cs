public class CleansingCenter : Center
{
    public CleansingCenter(string name) 
        : base(name)
    {
    }

    public void CleanseAllAnimals()
    {
        foreach (var animal in base.StoredAnimals)
        {
            animal.CleansingStatus = "CLEANSED";
        }
        base.StoredAnimals.Clear();
    }
}
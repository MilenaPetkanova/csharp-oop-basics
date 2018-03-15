using System.Collections.Generic;

public abstract class Center : ICenter
{
    protected Center(string name)
    {
        this.Name = name;
        this.StoredAnimals = new List<Animal>();
    }

    public string Name { get; private set; }

    public List<Animal> StoredAnimals { get; protected set; }
    
}
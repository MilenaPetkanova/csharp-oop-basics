using System.Collections.Generic;

public abstract class Center : ICenter
{
    protected Center(string name)
    {
        this.Name = name;
        this.StoredAnimals = new List<IAnimal>();
    }

    public string Name { get; private set; }

    public List<IAnimal> StoredAnimals { get; protected set; }
    
}
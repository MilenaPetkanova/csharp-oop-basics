using System.Collections.Generic;

public interface ICenter
{
    string Name { get; }

    List<Animal> StoredAnimals { get; }
}

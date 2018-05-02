using System.Collections.Generic;

public interface ICenter
{
    string Name { get; }

    List<IAnimal> StoredAnimals { get; }
}

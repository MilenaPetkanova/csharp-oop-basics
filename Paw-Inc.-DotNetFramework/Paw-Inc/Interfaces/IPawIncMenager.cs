using System.Collections.Generic;

public interface IPawIncMenager
{
    List<CleansingCenter> CleansingCenters { get; }
    List<AdoptionCenter> AdoptionCenters { get; }
    List<IAnimal> AdoptedAnimals { get; }

    void RegisterCleansingCenter(string name);
    void RegisterAdoptionCenter(string name);
    void RegisterDog(string name, int age, int learnedCommands, string adoptionCenterName);
    void RegisterCat(string name, int age, int intelligenceCoefficient, string adoptionCenterName);
    void SendForCleansing(string adoptionCenterName, string cleansingCenterName);
    void Cleanse(string cleansingCenterName);
    void Adopt(string adoptionCenterName);
    void Report();
}

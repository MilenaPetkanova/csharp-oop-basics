public interface IHarvester
{
    string Id { get; }

    double OreOutput { get; }

    double EnergyRequirement { get; }

    void ConsumeEnergy(double consumation);

    double MinePlumbusOre(double ore);
}

using System;

public class Provider : IProvider
{
    private string id;
    private double energyOutput;

    public Provider(string id, double energy)
    {
        this.Id = id;
        this.EnergyOutput = energy;
    }

    public string Id
    {
        get => this.id;
        set => this.id = value;
    }

    public double EnergyOutput
    {
        get => this.energyOutput;
        protected set
        {
            if (value <= 0 || value >= 10000)
            {
                throw new ArgumentException($"Provider is not registered, because of it's {nameof(this.EnergyOutput)}");
            }
            this.energyOutput = value;
        }
    }

    public double ProduceEnergy()
    {
        return this.energyOutput;
    }
}
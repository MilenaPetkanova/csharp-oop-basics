using System;

public abstract class Provider : Unit
{
    private double energyOutput;

    public Provider(string id, double energy) 
        : base(id)
    {
        this.EnergyOutput = energy;
    }

    public double EnergyOutput
    {
        get => this.energyOutput;
        protected set
        {
            if (value < 0 || value >= 10000)
            {
                throw new ArgumentException($"Provider is not registered, because of it's {nameof(this.EnergyOutput)}");
            }
            this.energyOutput = value;
        }
    }

    public override string ToString()
    {
        var output = $"{this.Type} Provider - {base.Id}" + Environment.NewLine +
                    $"Energy Output: {this.energyOutput}";
        return output;
    }
}
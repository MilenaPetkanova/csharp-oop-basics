using System;

public abstract class Tyre : ITyre
{
    private string name;
    private double hardness;
    private double degradation;

    protected Tyre(string name, double hardness)
    {
        this.Name = name;
        this.Hardness = hardness;
        this.Degradation = 100;
    }

    public string Name
    {
        get => this.name;
        protected set
        {
            if (value != "UltrasoftTyre" && value != "HardTyre")
            {
                throw new ArgumentException("Invalid tyre name!");
            }
            this.name = value;
        }
    }

    public double Hardness
    {
        get => this.hardness;
        protected set => this.hardness = value;
    }

    public double Degradation
    {
        get => this.degradation;
        protected set => this.degradation = value;
    }

    public virtual void ReduceDegradation()
    {
        this.degradation -= this.hardness;
        if (this.degradation <= 0)
        {
            throw new ArgumentException("Tyre blows up!");
        }
    }
}
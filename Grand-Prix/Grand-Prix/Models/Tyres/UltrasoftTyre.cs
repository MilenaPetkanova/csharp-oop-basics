using System;

public class UltrasoftTyre : Tyre
{
    public UltrasoftTyre(string name, double hardness, double grid)
        : base(name, hardness)
    {
        this.Grip = grid;
    }

    public double Grip { get; private set; }

    public override void ReduceDegradation()
    {
        base.Degradation -= base.Hardness + this.Grip;
        if (base.Degradation < 30)
        {
            throw new ArgumentException("Tyre blows up!");
        }
    }
}

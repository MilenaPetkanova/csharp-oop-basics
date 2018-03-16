using System;

public class UltrasoftTyre : Tyre
{
    public UltrasoftTyre(double hardness, double grid)
        : base(hardness)
    {
        this.Grip = grid;
    }

    public override string Name => "Ultrasoft";

    public double Grip { get; private set; }

    public override double Degradation
    {
        get => base.Degradation;
        protected set
        {
            if (value < 30)
            {
                throw new ArgumentException(ErrorMessages.BlownTyre);
            }
            base.Degradation = value;
        }
    }

    public override void ReduceDegradation()
    {
        base.Degradation -= base.Hardness + this.Grip;
    }
}

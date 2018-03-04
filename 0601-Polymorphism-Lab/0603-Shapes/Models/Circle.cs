using System;

public class Circle : Shape
{
    private double radius;

    public Circle(double radius)
    {
        this.Radius = radius;
    }

    public double Radius
    {
        get => this.radius;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(this.radius), "Width should be possitive number!");
            }
            radius = value;
        }
    }

    public override double CalculatePerimeter()
    {
        var result = 2 * Math.PI * this.radius;
        return result;
    }

    public override double CalculateArea()
    {
        var result = Math.PI * this.radius * this.radius;
        return result;
    }

    public override string Draw()
    {
        return base.Draw() + "Circle";
    }
}
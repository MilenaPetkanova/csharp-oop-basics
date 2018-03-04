using System;

public class Rectangle : Shape
{
    private double height;
    private double width;

    public Rectangle(double height, double width)
    {
        this.Height = height;
        this.Width = width;
    }

    public double Height
    {
        get => this.height;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(this.width), "Width should be possitive number!");
            }
            height = value;
        }
    }

    public double Width
    {
        get => this.width;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(this.width), "Width should be possitive number!");
            }
            width = value;
        }
    }

    public override double CalculateArea()
    {
        var result = this.height * this.width;
        return result;
    }

    public override double CalculatePerimeter()
    {
        var result = this.height * 2 + this.width * 2;
        return result;
    }

    public override string Draw()
    {
        return base.Draw() + "Rectangle";
    }
}
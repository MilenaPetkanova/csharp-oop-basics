using System;
using System.Text;

public class Box
{
    const string ERROR_MESSAGE = "cannot be zero or negative.";
    private double length;
    private double width;
    private double height;

    public double Length
    {
        get => this.length;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Length {ERROR_MESSAGE}");
            }
            this.length = value;
        }
    }

    public double Width
    {
        get => this.width;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Width {ERROR_MESSAGE}");
            }
            this.width = value;
        }
    }

    public double Height
    {
        get => this.height;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException($"Height {ERROR_MESSAGE}");
            }
            this.height = value;
        }
    }

    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    public double LateralSurfaceArea()
    {
        return 2 * this.length * this.height + 2 * this.width * this.height;
    }

    public double SurfaceArea()
    {
        return 2 * this.length * this.width + 2 * this.length * this.height + 2 * this.width * this.Height;
    }

    public double Volume()
    {
        return this.length * this.width * this.height;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Surface Area - {SurfaceArea():F2}");
        sb.AppendLine($"Lateral Surface Area - {LateralSurfaceArea():F2}");
        sb.Append($"Volume - {Volume():F2}");
        return sb.ToString();
    }
}
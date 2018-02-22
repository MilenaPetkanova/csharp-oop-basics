using System.Text;

public class Box
{
    public double Length { get; set; }
    public double Width { get; set; }
    public double Heigth { get; set; }
    public double SurfaceArea { get; set; }
    public double LateralSurfaceArea { get; set; }
    public double Volume { get; set; }

    public Box(double length, double width, double heigth)
    {
        this.Length = length;
        this.Width = width;
        this.Heigth = heigth;
        CalculateLateralSurfaceArea();
        CalculateSurfaceArea();
        CalculateVolume();
    }

    public void CalculateLateralSurfaceArea()
    {
        LateralSurfaceArea = 2 * Length * Heigth + 2 * Width * Heigth;
    }

    public void CalculateSurfaceArea()
    {
        SurfaceArea = 2 * Length * Width + LateralSurfaceArea;
    }

    public void CalculateVolume()
    {
        Volume = Length * Width * Heigth;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Surface Area - {SurfaceArea:F2}");
        sb.AppendLine($"Lateral Surface Area - {LateralSurfaceArea:F2}");
        sb.Append($"Volume - {Volume:F2}");
        return sb.ToString();
    }
}
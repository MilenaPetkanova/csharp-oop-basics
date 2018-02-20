public class Cymric : Cat
{
    public double FurLength { get; set; }

    public string Type { get; set; }

    public override string ToString()
    {
        return $"Cymric {this.Name} {this.FurLength:f2}";
    }
}
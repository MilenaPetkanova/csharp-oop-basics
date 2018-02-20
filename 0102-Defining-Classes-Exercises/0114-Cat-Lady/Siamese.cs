public class Siamese : Cat
{
    public int EarSize { get; set; }

    public override string ToString()
    {
        return $"Siamese {this.Name} {this.EarSize}";
    }
}
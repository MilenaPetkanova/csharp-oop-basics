public class StreetExtraordinaire : Cat
{
    public int DecibelsOfMeows { get; set; }

    public override string ToString()
    {
        return $"StreetExtraordinaire {this.Name} {this.DecibelsOfMeows}";
    }
}
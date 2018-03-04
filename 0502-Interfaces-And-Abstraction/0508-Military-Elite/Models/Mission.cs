public class Mission
{
    public override string ToString()
    {
        return $"Code Name: {this.CodeName} State: {this.State}";
    }

    public string CodeName { get; set; }

    public string State { get; set; }
}
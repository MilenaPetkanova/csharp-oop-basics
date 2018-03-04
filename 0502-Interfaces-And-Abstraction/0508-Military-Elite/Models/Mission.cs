public class Mission
{
    public string CodeName { get; set; }
    public string State { get; set; }

    public override string ToString()
    {
        return $"Code Name: {this.CodeName} State: {this.State}";
    }
}
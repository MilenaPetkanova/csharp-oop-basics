public class Spy : Soldier, ISpy
{
    private int codeNumber;

    public Spy(string id, string firstName, string lastName, int codeNum)
        : base (id, firstName, lastName)
    {
        this.CodeNumber = codeNum;
    }

    public int CodeNumber
    {
        get => this.codeNumber;
        private set => this.codeNumber = value;S
    }

    public override string ToString()
    {
        return base.ToString() + $"\nCode Number: {this.CodeNumber}";
    }
}
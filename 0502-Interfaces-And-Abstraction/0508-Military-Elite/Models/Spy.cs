public class Spy : Soldier, ISpy
{
    public Spy(string id, string firstName, string lastName, int codeNum)
        : base (id, firstName, lastName)
    {
        this.CodeNumber = codeNum;
    }

    public int CodeNumber { get; private set; }

    public override string ToString()
    {
        return base.ToString() + $"\nCode Number: {this.CodeNumber}";
    }
}
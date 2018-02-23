using System.Collections.Generic;

public class StackOfStrings
{
    private List<string> data;

    public StackOfStrings()
    {
        this.data = new List<string>();
    }

    public void Push(string item)
    {
        this.data.Add(item);
    }

    public string Pop()
    {
        this.data.RemoveAt(data.Count - 1);
        return this.data[data.Count - 1];
    }

    public string Peek()
    {
        return this.data[data.Count - 1];
    }

    public bool IsEmpty()
    {
        return data.Count == 0 ? true : false;
    }
}
class Startup
{
    static void Main()
    {
        // test class StackOfStrings

        var myStack = new StackOfStrings();
        myStack.Push("a");
        myStack.Push("b");
        myStack.Push("c");
        myStack.Pop();
        string peek = myStack.Peek();
        bool isEmpty = myStack.IsEmpty();
    }
}

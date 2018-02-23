public class Dog : Animal
{
    public void Bark()
    {
        System.Console.WriteLine("barking...");
    }

    public override string ToString()
    {
        return base.ToString();
    }
}
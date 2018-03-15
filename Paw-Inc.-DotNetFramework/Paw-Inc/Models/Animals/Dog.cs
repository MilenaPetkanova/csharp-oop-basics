public class Dog : Animal
{
    public Dog(string name, int age, int learnedCommands) 
        : base(name, age)
    {
        this.AmountOfCommands = learnedCommands;
    }

    public int AmountOfCommands { get; private set; }
}
    

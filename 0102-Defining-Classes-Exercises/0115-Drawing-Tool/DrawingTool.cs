public abstract class DrawingTool
{
    public int FirstParam { get; set; }
    public int SecondParam { get; set; }

    public abstract void Draw();

}

public class Square : DrawingTool
{
    public override void Draw()
    {
        System.Console.WriteLine("{0}{1}{0}", new string('|', 1), new string('-', this.FirstParam));
        for (int i = 0; i < this.FirstParam - 2; i++)
        {
            System.Console.WriteLine("{0}{1}{0}", new string('|', 1), new string(' ', this.FirstParam));
        }
        if (this.FirstParam != 1)
        {
            System.Console.WriteLine("{0}{1}{0}", new string('|', 1), new string('-', this.FirstParam));
        }
    }
}

public class Rectangle : DrawingTool
{
    public override void Draw()
    {
        System.Console.WriteLine("{0}{1}{0}", new string('|', 1), new string('-', this.FirstParam));
        for (int i = 0; i < this.SecondParam - 2; i++)
        {
            System.Console.WriteLine("{0}{1}{0}", new string('|', 1), new string(' ', this.FirstParam));
        }
        if (this.SecondParam != 1)
        {
            System.Console.WriteLine("{0}{1}{0}", new string('|', 1), new string('-', this.FirstParam));
        }
    }
}


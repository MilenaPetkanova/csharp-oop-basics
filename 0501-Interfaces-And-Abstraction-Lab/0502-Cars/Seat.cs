using System.Text;

public class Seat : ICar
{
    private string model;
    private string color;

    public Seat(string model, string color)
    {
        this.model = model;
        this.color = color;
    }

    public string Model => this.model;

    public string Color => this.color;

    public string Start()
    {
        return "Engine start";
    }

    public string Stop()
    {
        return "Breaaak!";
    }

    public override string ToString()
    {
        var output = new StringBuilder();
        output.AppendLine($"{this.color} {this.GetType()} {this.model}");
        output.AppendLine(this.Start());
        output.Append(this.Stop());

        return output.ToString();
    }
}
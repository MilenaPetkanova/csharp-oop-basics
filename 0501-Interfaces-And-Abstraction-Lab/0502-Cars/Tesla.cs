using System.Text;

public class Tesla : ICar, IElectricCar
{
    private string model;
    private string color;
    private int battery;

    public Tesla(string model, string color, int battery)
    {
        this.model = model;
        this.color = color;
        this.battery = battery;
    }

    public string Model => this.model;

    public string Color => this.color;

    public int Battery => this.battery;

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
        output.AppendLine($"{this.color} {this.GetType()} {this.model} with {this.battery} Batteries");
        output.AppendLine(this.Start());
        output.Append(this.Stop());

        return output.ToString();
    }
}
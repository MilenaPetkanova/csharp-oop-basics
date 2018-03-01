public class Ferrari : IDrivable
{
    private string model;
    private string driver;

    public Ferrari(string model, string driver)
    {
        this.Model = model;
        this.Driver = driver;
    }

    public string Model
    {
        get => this.model;
        private set => this.model = value;
    }

    public string Driver
    {
        get => this.driver;
        private set => this.driver = value;
    }

    public string PushGasPedal()
    {
        return "Zadu6avam sA!";
    }

    public string UseBrakes()
    {
        return "Brakes!";
    }

    public override string ToString()
    {
        return $"{this.model}/{this.UseBrakes()}/{this.PushGasPedal()}/{this.driver}";
    }
}
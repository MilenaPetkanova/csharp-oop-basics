public class Car
{
    private string model;
    private double fuelAmount;
    private double fuelPerKm;
    private int distance = 0;

    public int Distance
    {
        get { return distance; }
        set { distance = value; }
    }

    public double FuelPerKm
    {
        get { return fuelPerKm; }
        set { fuelPerKm = value; }
    }

    public double FuelAmount
    {
        get { return fuelAmount; }
        set { fuelAmount = value; }
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public bool EnoughtFuel(int amountKm)
    {
        bool isEnought = false;
        if (this.FuelPerKm * amountKm <= this.FuelAmount)
        {
            isEnought = true;
        }
        return isEnought;
    }
}

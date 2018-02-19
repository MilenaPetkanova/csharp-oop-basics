using System.Collections.Generic;

class Car
{
    private string model;
    private Engine engine;
    private Cargo cargo;
    private List<Tire> tires;

    public Car(string model, int engineSpeed, int enginePower,
        int cargoWeight, string cargoType,
        double tire1Pressure, int tire1Age, double tire2Pressure, int tire2Age, double tire3Pressure, int tire3Age, double tire4Pressure, int tire4Age)
    {
        this.model = model;

        this.Engine = new Engine();
        this.engine.EngineSpeed = engineSpeed;
        this.engine.EnginePower = enginePower;

        this.Cargo = new Cargo();
        this.cargo.CargoType = cargoType;
        this.cargo.CargoWeight = cargoWeight;

        this.tires = new List<Tire>(4);

        var tire1 = new Tire();
        tire1.TirePressure = tire1Pressure;
        tire1.TireAge = tire1Age;
        var tire2 = new Tire();
        tire2.TirePressure = tire2Pressure;
        tire2.TireAge = tire2Age;
        var tire3 = new Tire();
        tire3.TirePressure = tire3Pressure;
        tire3.TireAge = tire3Age;
        var tire4 = new Tire();
        tire4.TirePressure = tire4Pressure;
        tire4.TireAge = tire4Age;

        this.tires.Add(tire1);
        this.tires.Add(tire2);
        this.tires.Add(tire3);
        this.tires.Add(tire4);
    }

    public List<Tire> Tires
    {
        get { return tires; }
        set { tires = value; }
    }

    public Cargo Cargo
    {
        get { return cargo; }
        set { cargo = value; }
    }

    public Engine Engine
    {
        get { return engine; }
        set { engine = value; }
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }
}

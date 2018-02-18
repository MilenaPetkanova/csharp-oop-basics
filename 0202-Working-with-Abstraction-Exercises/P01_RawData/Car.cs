using System.Collections.Generic;
using System.Linq;

public class Car
{
    private string model;
    private List<Tire> tires;
    private Engine engine;
    private Cargo cargo;

    public string Model { get; set; }
    public List<Tire> Tires { get; set; }
    public Engine Engine { get; set; }
    public Cargo Cargo { get; set; }

    public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType, double tire1Pressure, int tire1Age, double tire2Pressure, int tire2Age, double tire3Pressure, int tire3Age, double tire4Pressure, int tire4Age)
    {
        this.Model = model;
        this.Tires = new List<Tire>();
        this.Tires.Add(new Tire(tire1Pressure, tire1Age));
        this.Tires.Add(new Tire(tire2Pressure, tire2Age));
        this.Tires.Add(new Tire(tire3Pressure, tire3Age));
        this.Tires.Add(new Tire(tire4Pressure, tire4Age));
        this.Engine = new Engine(engineSpeed, enginePower);
        this.Cargo = new Cargo(cargoWeight, cargoType);
    }
}
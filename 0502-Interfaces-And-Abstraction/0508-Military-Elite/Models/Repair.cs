public class Repair 
{
    public override string ToString()
    {
        return $"Part Name: {this.PartName} Hours Worked: {this.HoursWorked}";
    }

    public string PartName { get; set; }

    public int HoursWorked { get; set; }
}
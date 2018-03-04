public class Repair 
{
    public string PartName { get; set; }
    public int HoursWorked { get; set; }

    public override string ToString()
    {
        return $"Part Name: {this.PartName} Hours Worked: {this.HoursWorked}";
    }
}
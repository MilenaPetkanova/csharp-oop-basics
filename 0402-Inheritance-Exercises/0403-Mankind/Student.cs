using System;
using System.Linq;

public class Student : Human
{
    private const int MIN_FACILITY_NUMBER = 5;
    private const int MAX_FACILITY_NUMBER = 10;

    private string facultyNumber;

    public string FacultyNumber
    {
        get => this.facultyNumber; 
        protected set
        {
            if (!value.All(x => char.IsLetterOrDigit(x)))
            {
                throw new ArgumentException("Invalid faculty number!");
            }
            else if (value.Length < MIN_FACILITY_NUMBER || value.Length > MAX_FACILITY_NUMBER)
            {
                throw new ArgumentException("Invalid faculty number!");
            }
            this.facultyNumber = value;
        }
    }

    public Student(string firstName, string secondName, string facultyNum) 
        : base(firstName, secondName)
    {
        this.FacultyNumber = facultyNum;
    }

    public override string ToString()
    {
        return $"{base.ToString()}" + Environment.NewLine 
            + $"Faculty number: {this.facultyNumber}";
    }
}

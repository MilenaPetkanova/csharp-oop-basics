using System;

public class Worker : Human
{
    private const int MIN_WEEK_SALARY = 11;
    private const int MIN_WORKING_HOURS = 1;
    private const int MAX_WORKING_HOURS = 12;

    private decimal weekSalary;
    private double workingHours;

    public Worker(string firstName, string secondName, decimal salary, double workingHours)
    : base(firstName, secondName)
    {
        this.WorkingHours = workingHours;
        this.WeekSalary = salary;
    }

    public decimal WeekSalary
    {
        get => this.weekSalary;
        protected set
        {
            if (value < MIN_WEEK_SALARY)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }
            this.weekSalary = value;
        }
    }

    public double WorkingHours
    {
        get => this.workingHours;
        protected set
        {
            if (value < MIN_WORKING_HOURS || value > MAX_WORKING_HOURS)
            {
                throw new ArgumentException($"Expected value mismatch! Argument: workHoursPerDay");
            }
            this.workingHours = value;
        }
    }

    private decimal CalculateSalaryPerHour()
    {
        return this.weekSalary / 5 / (decimal)this.workingHours;
    }

    public override string ToString()
    {
        return $"{base.ToString()}" + Environment.NewLine
            + $"Week Salary: {this.weekSalary:F2}" + Environment.NewLine
            + $"Hours per day: {this.workingHours:F2}" + Environment.NewLine
            + $"Salary per hour: {this.CalculateSalaryPerHour():F2}";
    }
}
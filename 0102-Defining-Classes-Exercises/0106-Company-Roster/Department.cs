using System.Collections.Generic;
using System.Linq;

public class Department
{
    private List<Employee> employees;
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public List<Employee> Employees
    {
        get { return employees; }
        set { employees = value; }
    }

    public Department(string name)
    {
        this.Employees = new List<Employee>();
        this.Name = name;
    }

    public decimal CalculateAverage()
    {
        return this.Employees.Select(e => e.Salary).Average();
    }

    public void AddEmployee(Employee employee)
    {
        this.Employees.Add(employee);
    }
}
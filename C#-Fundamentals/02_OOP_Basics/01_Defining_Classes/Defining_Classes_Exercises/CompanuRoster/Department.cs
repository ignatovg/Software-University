using System.Collections.Generic;
using System.Linq;

public class Department
{
    public List<Employee> Employees { get; private set; }
    public string Name { get; set; }
    
    public Department(string name)
    {
        this.Employees = new List<Employee>();
        this.Name = name;
    }

    public decimal AverageSalary
    {
        get { return this.Employees.Select(e => e.Salary).Average(); }
    }

    public void AddEmployee(Employee employee)
    {
        this.Employees.Add(employee);
    }
}
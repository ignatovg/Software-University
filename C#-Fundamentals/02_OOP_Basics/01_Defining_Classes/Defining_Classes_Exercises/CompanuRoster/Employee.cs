
using System;
using System.Reflection.Metadata.Ecma335;

public class Employee
{
    public string Name { get; set; }
    public decimal Salary { get; set; }
    public string Position { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }



    public Employee(string name, decimal salary, string position, int age = -1, string email = "n/a")
    {
        this.Name = name;
        this.Salary = salary;
        this.Position = position;
        this.Age = age;
        this.Email = email;
    }

}


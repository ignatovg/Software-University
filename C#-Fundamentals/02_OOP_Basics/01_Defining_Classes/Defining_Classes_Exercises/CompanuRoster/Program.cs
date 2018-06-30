using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanuRoster
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Department> departments = new List<Department>();

            //name, salary, position, department, email and age
            for (int i = 0; i < n; i++)
            {
                string[] emInput = Console.ReadLine().Split(' ');
                string name = emInput[0];
                decimal salary = decimal.Parse(emInput[1]);
                string position = emInput[2];
                string depName = emInput[3];
                string email = "n/a";
                int age = -1;

                if (emInput.Length == 6)
                {
                    email = emInput[4];
                    age = int.Parse(emInput[5]);
                }
                else if (emInput.Length == 5)
                {
                    bool isAge = int.TryParse(emInput[4], out age);
                    if (!isAge)
                    {
                        email = emInput[4];
                        age = -1;
                    }
                }
                if (!departments.Any(d=>d.Name== depName))
                {
                    Department dep = new Department(depName);
                    departments.Add(dep);
                }
                var department = departments.FirstOrDefault(d => d.Name == depName);
                
                Employee employee = new Employee(name, salary, position, age, email);
                 department.AddEmployee(employee);
            }
           var highestAvgDep = departments.OrderByDescending(d=>d.AverageSalary).First();
            Console.WriteLine($"Highest Average Salary: {highestAvgDep.Name}");

            foreach (var employee in highestAvgDep.Employees.OrderByDescending(e=>e.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:f2} {employee.Email} {employee.Age}");
            }
        }
    }
}

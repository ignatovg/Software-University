using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeData
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string firstName = Console.ReadLine();
            Console.WriteLine($"First name: {firstName}");

            string lastName = Console.ReadLine();
            Console.WriteLine($"Last name: {lastName}");

            int age=int.Parse(Console.ReadLine());
            Console.WriteLine($"Age: {age}");

            char gander=char.Parse(Console.ReadLine());
            Console.WriteLine($"Gender: {gander}");

            long idNumber=long.Parse(Console.ReadLine());
            Console.WriteLine($"Personal ID: {idNumber}");

            uint employeeNumber = uint.Parse(Console.ReadLine());
            Console.WriteLine($"Unique Employee number: {employeeNumber}");
        }
    }
}

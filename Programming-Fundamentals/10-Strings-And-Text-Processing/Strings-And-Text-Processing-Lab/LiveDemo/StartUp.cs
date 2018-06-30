using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveDemo
{
    class Student
    {
        public string Name { get; set; }
    }
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Student> students=new List<Student>();
            HashSet<string> names=new HashSet<string>(); // не зависи от бр. студенти

            //речник от String and Student, също е вариант

            while (true)
            {
   string name = Console.ReadLine();

                if (!names.Contains(name))
                {
                    students.Add(new Student() {Name = name});
                    names.Add(name);
                }
                else
                {
                    Console.WriteLine("Already added.");
                }
            }
        }
    }
}

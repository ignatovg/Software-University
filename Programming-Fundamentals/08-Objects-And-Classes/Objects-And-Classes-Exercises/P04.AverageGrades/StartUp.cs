using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.AverageGrades
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n=int.Parse(Console.ReadLine());
            List<Student> students=new List<Student>();

            for (int i = 0; i < n; i++)
            {
                Student student = ReadStudent();
                students.Add(student);
               
            }

            foreach (Student student in students.Where(a=>a.Average>=5).OrderBy(a=>a.Name).ThenByDescending(a=>a.Average))
            {
                Console.WriteLine($"{student.Name} -> {student.Average:f2}");
            }
            
        }

        private static Student ReadStudent()
        {
            string[] tokens = Console.ReadLine().Split(' ');

            Student student = new Student
            {
                Name = tokens[0],
                Grades = tokens.Skip(1).Select(double.Parse).Take(tokens.Length-1).ToList(),
            
            };
            return student;
        }
    }

    class Student
    {
        public string Name { get; set; }
        public List<double> Grades { get; set; }

        public double Average
        {
            get
            {
                return Grades.Average();
            }
        }


      
    }
}

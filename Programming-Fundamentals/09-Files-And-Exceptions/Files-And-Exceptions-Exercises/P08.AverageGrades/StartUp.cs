using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P08.AverageGrades
{
    class Student
    {
        public string Name { get; set; }
        public double[] Grades { get; set; }
        public double Average => Grades.Average();
    }
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");
            int n = int.Parse(input[0]);
            List<Student> students=new List<Student>();

            for (int i = 1; i <= n; i++)
            {
                string[] tokens = input[i].Split(' ');
                string name = tokens[0];
                double[] grades = tokens.Skip(1).Select(double.Parse).ToArray();


                Student student=new Student();
                student.Name = name;
                student.Grades = grades;

                students.Add(student);
            }
            File.WriteAllText("output.txt",string.Empty);
            foreach (var student in students.Where(x=>x.Average>5.00).OrderBy(x=>x.Name).ThenByDescending(x=>x.Average))
            {
                File.AppendAllText("output.txt",$"{student.Name} -> {student.Average:f2}"+Environment.NewLine);
            }
        }
    }
}

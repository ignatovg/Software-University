using System;
using System.Collections.Generic;

class StudentSystem
{
     Dictionary<string, Student> Repo { get;}

    public StudentSystem()
    {
        this.Repo = new Dictionary<string, Student>();
    }


    public void ParseCommand(string commandArgs)
    {
        string[] args = commandArgs.Split();

        if (args[0] == "Create")
        {
            string name = args[1];
            int age = int.Parse(args[2]);
            double grade = double.Parse(args[3]);

            Create(name, age, grade);
        }
        else if (args[0] == "Show")
        {
            var name = args[1];
            Show(name);
        }
    }

    private void Show(string name)
    {
        if (Repo.ContainsKey(name))
        {
            var student = Repo[name];
            
            Console.WriteLine(student.ToString());
        }
    }

    private void Create(string name, int age, double grade)
    {

        if (!Repo.ContainsKey(name))
        {
            var student = new Student(name, age, grade);
            Repo[name] = student;
        }
    }
}

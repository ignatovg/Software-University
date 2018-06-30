using System;
using System.Text;
using System.Text.RegularExpressions;

public class Student : Human
{
    private const string FacultyNumberPattern = @"^[A-Za-z\d]{5,10}$";
    private string facultyNum;

    public string FacultyNum
    {
        get { return facultyNum; }
        set
        {
            if (!Regex.IsMatch(value, FacultyNumberPattern))
            {
                throw new ArgumentException("Invalid faculty number!");
            }

            if (value.Length < 5 || value.Length > 10)
            {
                throw new ArgumentException($"Invalid faculty number!");
            }
            facultyNum = value;
        }
    }

    public Student(string firstName, string lastName, string facultyNum) : base(firstName, lastName)
    {
        FacultyNum = facultyNum;
    }

    public override string ToString()
    {
        StringBuilder resultBuilder = new StringBuilder();
        resultBuilder
            .AppendLine(base.ToString())
            .AppendLine($"Faculty number: {FacultyNum}");

        string result = resultBuilder.ToString().TrimEnd();
        return result;
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace FuncDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> csharpParser = int.Parse;
            Func<string,int> moreClear = (string text) => int.Parse(text);
            Func<string, int> lessClear = text => int.Parse(text);
            Func<int, int, int> sum = (x, y) => x + y;
            Func<string, decimal, string> pesho = (name, grade) => name + " " + grade;
            Func<string, List<int>, string> prakash = (personName, grades) => personName + " " + grades.Average();
            Func<string, string, string> gosho = (firstName, LastName) => $"{firstName} {LastName}";
            var number = int.Parse("5");
            var fullName = gosho("Georgi", "Ivanov");

        }
    }
}

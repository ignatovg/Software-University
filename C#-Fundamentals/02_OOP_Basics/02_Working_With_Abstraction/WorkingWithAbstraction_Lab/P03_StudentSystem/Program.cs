using System;

namespace P03_StudentSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentSystem studentSystem = new StudentSystem();

            string commandArgs = string.Empty;
            while ((commandArgs = Console.ReadLine())!= "Exit")
            {
                studentSystem.ParseCommand(commandArgs);
            }
        }
    }
}

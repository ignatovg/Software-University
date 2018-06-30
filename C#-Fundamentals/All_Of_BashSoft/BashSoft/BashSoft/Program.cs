using System;

namespace BashSoft
{
    class Program
    {
        static void Main()
        {
           IOManager.TraverseDirectory(@"D:\SoftUni\C#-Fundamentals");

            StudentsRepository.InitializeDate();
            StudentsRepository.GetAllStudentsFromCourse(@"../data.txt");
        }
    }
}

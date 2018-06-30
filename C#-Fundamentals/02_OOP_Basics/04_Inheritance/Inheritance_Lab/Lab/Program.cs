using System;

namespace Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            var uTeacher = new UniversityTeacher(20);
            Person person = uTeacher;
            Teacher teacher = uTeacher;
          //  Teacher teacher2 = person;
        }

        static void PrintPersonAdress(object person)
        {
            if (person is Teacher)
            {
                var teacher = (Teacher) person;
                Console.WriteLine();
            }
            
        }
    }
}

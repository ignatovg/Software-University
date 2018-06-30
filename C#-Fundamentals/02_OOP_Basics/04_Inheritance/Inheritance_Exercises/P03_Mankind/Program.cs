using System;

namespace P03_Mankind
{
    class Program
    {
        static void Main(string[] args)
        {
            //ctr+k+s
            try
            {
                string[] studentInput = Console.ReadLine().Split();
                Student student = new Student(studentInput[0], studentInput[1], studentInput[2]);

                string[] workerInput = Console.ReadLine().Split();
                Worker worker = new Worker(workerInput[0], workerInput[1], decimal.Parse(workerInput[2]), double.Parse(workerInput[3]));

                Console.WriteLine(student + Environment.NewLine);
                Console.WriteLine(worker);
            }
            catch (Exception ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}

using System;

namespace Lab
{
    class Program
    {
        public delegate  void WorkPerformedHandler(int hours, int minutes);


        static void Main(string[] args)
        {
            WorkPerformedHandler dele = new WorkPerformedHandler(WorkPerformed);
        }

        private static void WorkPerformed(int hours, int minutes)
        {
            Console.WriteLine("WorkPerformed called " + hours.ToString());
        }
    }
}

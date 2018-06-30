using System;

namespace P10_ExplicitInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            string readName;
            while ((readName=Console.ReadLine())!="End")
            {
                string[] tokens = readName.Split();
                string name = tokens[0];
                string country = tokens[1];
                int age = int.Parse(tokens[2]);

                Citizen citizen = new Citizen(name, country, age);
                
                IResident resident = new Citizen(name,country,age);
                var person = (IPerson)resident;
                person.GetName();
                resident.GetName();
                
            }
        }
    }
}

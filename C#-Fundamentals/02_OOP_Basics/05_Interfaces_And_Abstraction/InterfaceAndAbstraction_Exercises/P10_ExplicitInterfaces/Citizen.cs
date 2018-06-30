using System;
using System.Collections.Generic;
using System.Text;

namespace P10_ExplicitInterfaces
{
    class Citizen : IPerson, IResident
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }

        public Citizen(string name, string country, int age)
        {
            this.Name = name;
            this.Country = country;
            this.Age = age;
        }

         void IResident.GetName()
        {
            Console.WriteLine("Mr/Ms/Mrs "+this.Name);
        }

         void IPerson.GetName()
        {
            Console.WriteLine(this.Name);
        }




    }
}

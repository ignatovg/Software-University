using System;

namespace Lab
{
    class Program
    {
        static void Main(string[] args)
        {
           Person person = new Person();
            person.SetAge(23);
            person.IncreaseAgeByOne().Print();

            Console.WriteLine();
            person.Print();
            //-----------------------------

            var animal = new Animal();
           // animal.Name = "sheep";
            var dog = new Dog();
           // dog.Name = "dog";


        }
    }
}

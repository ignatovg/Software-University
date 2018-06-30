using System;
using System.Collections.Generic;
using System.Linq;

namespace Bojo_FamilyTree
{
    class Program
    {
        private static List<Person> familyTree;
        static void Main(string[] args)
        {
            familyTree = new List<Person>();

            string personInput = Console.ReadLine();
            Person mainPerson= new Person();

            if (IsBirthday(personInput))
            {
                mainPerson.Birthday = personInput;
            }
            else
            {
                mainPerson.Name = personInput;
            }
            //familyTree.Add(mainPerson);

            string command;
            while ((command=Console.ReadLine())!= "End")
            {
                string[] tokens = command.Split(" - ");
                if (tokens.Length>1)
                {
                    string firstPerson = tokens[0];
                    string secondPerson = tokens[1];

                    Person currentPerson;

                    if (IsBirthday(firstPerson))
                    {
                        currentPerson = familyTree.FirstOrDefault(p => p.Birthday == firstPerson);

                        if (currentPerson== null)
                        {
                            currentPerson = new Person();
                            currentPerson.Birthday = firstPerson;
                            familyTree.Add(currentPerson);
                        }

                        SetChaild(familyTree, currentPerson, secondPerson);
                    }
                    else
                    {
                        currentPerson = familyTree.FirstOrDefault(p => p.Name == firstPerson);

                        if (currentPerson == null)
                        {
                            currentPerson = new Person();
                            currentPerson.Name = firstPerson;
                            familyTree.Add(currentPerson);
                        }
                        SetChaild(familyTree, currentPerson, secondPerson);
                    }
                }
                else
                {
                    tokens = tokens[0].Split();
                    string name = $"{tokens[0]} {tokens[1]}";
                    string birthday = tokens[2];

                    var person = familyTree.FirstOrDefault(p => p.Name == name || p.Birthday == birthday);
                    if (person == null)
                    {
                        person = new Person();
                        familyTree.Add(person);
                    }
                    person.Name = name;
                    person.Birthday = birthday;

                    int index = familyTree.IndexOf(person)+1;
                    int count = familyTree.Count - index;

                    Person[] copy = new Person[count];
                    familyTree.CopyTo(index, copy, 0, count);

                    int copyIndex = Array.IndexOf(copy, person);


                    if (copyIndex >= 0)
                    {
                        familyTree.RemoveAt(index + copyIndex);    
                    }
                }
            }
            Console.WriteLine(mainPerson);
            Console.WriteLine("Parents:");
            foreach (var mainPersonParent in mainPerson.Parents)
            {
                Console.WriteLine(mainPersonParent);
            }
            Console.WriteLine("Childrean:");
            foreach (var mainPersonChild in mainPerson.Children)
            {
                Console.WriteLine(mainPersonChild);
            }
        }

        private static void SetChaild(List<Person> familyTree, Person parentPerson, string child)
        {
            var childPerson = new Person();

            if (IsBirthday(child))
            {
                if (!familyTree.Any(p => p.Birthday == child))
                {
                    childPerson.Birthday = child;
                }
                else
                {
                    childPerson = familyTree.Find(p => p.Birthday == child);
                }
            }
            else
            {
                if (!familyTree.Any(p => p.Name == child))
                {
                    childPerson.Name = child;
                }
                else
                {
                    childPerson = familyTree.Find(p => p.Name == child);
                }
            }
            parentPerson.Children.Add(childPerson);
            childPerson.Parents.Add(parentPerson);
            familyTree.Add(childPerson);
        }

        private static bool IsBirthday(string personInput)
        {
            return (Char.IsDigit(personInput[0]));

        }
    }
}

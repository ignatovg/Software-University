using System;
using System.Collections.Generic;

public class Person//:IComparable<Person>
{
    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public string Name { get; set; }

    public int Age { get; set; }
    
    public override string ToString()
    {
        return $"{this.Name} {this.Age}";
    }

    //public int CompareTo(Person other)
    //{
    //    int result = this.Age.CompareTo(other.Age);

    //    if (result == 0)
    //    {
    //        result = this.Name.CompareTo(other.Name);
    //    }
        

    //    return result;
    //}
}


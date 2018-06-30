using System;
using System.Collections.Generic;

public class Person:IComparable<Person>
{
    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public string Name { get; }

    public int Age { get; }

    public override string ToString()
    {
        return $"{this.Name} {this.Age}";
    }

    public override bool Equals(object obj)
    {
        if (obj is Person other)
        {
            return this.Name == other.Name && this.Age == other.Age;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return this.Name.GetHashCode()+this.Age.GetHashCode();
    }

    public int CompareTo(Person other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        var nameComparison = string.Compare(Name, other.Name, StringComparison.Ordinal);
        if (nameComparison != 0) return nameComparison;
        return Age.CompareTo(other.Age);
    }
}


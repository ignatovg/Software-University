using System;

class Person
{
    private int age;

    public int Age
    {
        get { return age; }
        //set { age = value; }
    }
    private string firstName;

    public string FirstName
    {
        get { return  firstName; }
        set { firstName = value; }
    }
    private string lastName;

    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }

    public bool SetAge(int newAge)
    {
        this.age = newAge;
        var isAgeValid = IsAgeValid(this);
        return true;
    }

    public static bool IsAgeValid(Person person)
    {
        return person.age >= 0;
    }

    public Person IncreaseAgeByOne()
    {
        this.age++;
        return this;
    }

    public void Print()
    {
        Console.WriteLine($"My age is {age}");
    }

    public Person()
    {
        this.age = 0;
    }

    public Person(string firstName, string lastName)
    {
        this.firstName = firstName;
        this.lastName = lastName;
    }

    public Person(string firstName, string lastName, int age)
        : this(firstName, lastName)
    {
        this.age = age;
    }
    
}

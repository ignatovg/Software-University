public class Person
{
    private string name;
    private int age;

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public int Age
    {
        get { return this.age; }
        set { this.age = value; }
    }

    public Person()
    {
        Name = "No name";
        Age = 1;
    }

    public Person(int age) : this()
    {
        this.Age = age;
    }

    public Person(int age, string name)
    {
        this.Age = age;
        this.Name = name;
    }

    public override string ToString()
    {
        return $"{Name} {Age}";
    }
}


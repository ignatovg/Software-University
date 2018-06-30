using System.Collections.Generic;

class Person
{
    public string Name { get; set; }
    public string Birthday { get; set; }
    public List<Person> Parents { get; set; }
    public List<Person> Children { get; set; }

    public Person()
    {
        this.Children = new List<Person>();
        this.Parents = new List<Person>();
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Birthday}";
    }
}


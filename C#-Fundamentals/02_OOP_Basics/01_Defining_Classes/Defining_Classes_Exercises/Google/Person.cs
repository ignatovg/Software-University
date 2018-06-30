using System.Collections.Generic;

class Person
{
    public Company Company { get; set; }
    public Car Car { get; set; }
    public List<Pokemon> Pokemons { get; set; }
    public List<Parent> Parents { get; set; }
    public List<Child> Childrens { get; set; }

    public Person()
    {
        Pokemons=new List<Pokemon>();
        Parents = new List<Parent>();
        Childrens = new List<Child>();
    }
}

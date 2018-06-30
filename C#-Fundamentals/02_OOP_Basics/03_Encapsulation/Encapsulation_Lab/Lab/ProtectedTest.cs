class Animal
{
    private string name;

    protected string Name
    {
        get { return name; }
        set { name = value; }
    }

}

class Dog:Animal
{
    public void Bark()
    {
        this.Name = "Dog";
    }
}

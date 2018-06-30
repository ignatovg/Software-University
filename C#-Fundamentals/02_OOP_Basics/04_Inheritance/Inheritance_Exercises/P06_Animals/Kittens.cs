public class Kittens:Cat
{
    public Kittens(string name, int age, string gender) : base(name, age, gender)
    {

    }

    public override string Gender => "Female"; 

    public override string ProduceSound()
    {
        return "Meow";
    }
}


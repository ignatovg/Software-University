class Cymric: Cat
{
    //public string Name { get; set; }
    public double FurLenght { get; set; }

    public override string ToString()
    {
        return $"Cymric {Name} {FurLenght:f2}";
    }
}

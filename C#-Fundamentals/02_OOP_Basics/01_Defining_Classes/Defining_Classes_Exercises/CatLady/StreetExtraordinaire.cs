class StreetExtraordinaire : Cat
{
   // public string Name { get; set; }
    public double DecibelsOfMeows { get; set; }

    public override string ToString()
    {
        return $"StreetExtraordinaire {Name} {DecibelsOfMeows}";
    }
}


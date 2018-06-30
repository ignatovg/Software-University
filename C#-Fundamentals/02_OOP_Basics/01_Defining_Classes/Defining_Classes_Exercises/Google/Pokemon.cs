public class Pokemon
{
    public string PokemonName { get; set; }
    public string PokemonType { get; set; }

    public override string ToString()
    {
        return $"{PokemonName} {PokemonType}\r\n";
    }
}
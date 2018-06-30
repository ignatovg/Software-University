using System.Collections.Generic;
using System.Linq;

class Trainer
{
    public int Badges { get; set; }
    public List<Pokemon> Pokemon { get; set; }

    public Trainer()
    {
        this.Pokemon = new List<Pokemon>();
        this.Badges = 0;
    }

    public void ReceiveBadge()
    {
        this.Badges += 1;
    }

    public void LosePokemonsHealth()
    {
        foreach (Pokemon pokemon in this.Pokemon)
        {
            pokemon.Health -= 10;
        }
    }
}


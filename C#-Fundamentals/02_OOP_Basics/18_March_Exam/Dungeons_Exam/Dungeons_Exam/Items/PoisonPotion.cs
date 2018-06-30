using System;
using System.Collections.Generic;
using System.Text;
using Dungeons_Exam.Characters;

namespace Dungeons_Exam.Items
{
    public class PoisonPotion:Item
    {
        public PoisonPotion()
        {
        }

        public override int Weight => 5;

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.DecreaseHealth(20);
        }

       
    }
}

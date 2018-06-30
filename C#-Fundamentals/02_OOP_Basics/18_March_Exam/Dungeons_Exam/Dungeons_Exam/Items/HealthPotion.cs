using System;
using System.Collections.Generic;
using System.Text;
using Dungeons_Exam.Characters;

namespace Dungeons_Exam.Items
{
  public  class HealthPotion:Item
    {
        public HealthPotion()
        {
        }

        public override int Weight => 5;

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.IncreaseHealth(20);
        }
    }
}

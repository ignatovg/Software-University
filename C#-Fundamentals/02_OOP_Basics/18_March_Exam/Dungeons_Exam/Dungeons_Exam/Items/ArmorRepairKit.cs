using System;
using System.Collections.Generic;
using System.Text;
using Dungeons_Exam.Characters;

namespace Dungeons_Exam.Items
{
    public class ArmorRepairKit : Item
    {
        public ArmorRepairKit()
        {
        }
        public override int Weight => 10;

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.RestoreArmor();
        }
    }
}

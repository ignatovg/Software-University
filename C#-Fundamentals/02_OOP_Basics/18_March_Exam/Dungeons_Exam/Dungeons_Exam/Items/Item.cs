
using System;
using Dungeons_Exam.Characters;

namespace Dungeons_Exam.Items
{
    public abstract class Item
    {
        public virtual int Weight { get; }

        public virtual void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException("Must be alive to perform this action!");
            }
        }

    }
}

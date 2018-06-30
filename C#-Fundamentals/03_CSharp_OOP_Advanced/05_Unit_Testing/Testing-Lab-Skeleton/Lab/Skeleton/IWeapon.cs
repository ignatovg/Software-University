using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Skeleton
{
    public interface IWeapon
    {
        void Attack(Target target);
        int AttackPoints(GetIndexBinder);
    }
}

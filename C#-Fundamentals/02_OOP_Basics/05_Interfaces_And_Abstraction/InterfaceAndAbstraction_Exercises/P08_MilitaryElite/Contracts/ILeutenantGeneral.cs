using System;
using System.Collections.Generic;
using System.Text;

namespace P08_MilitaryElite.Contracts
{
    public interface ILeutenantGeneral:IPrivate
    {
        IReadOnlyCollection<ISoldier> Privates { get; }
        void AddPrivate(ISoldier soldier);
    }
}

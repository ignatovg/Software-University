using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace P08_MilitaryElite.Contracts
{
    public interface ISpecialisedSoldier:IPrivate
    {
        Corpus Corps { get; }
    }
}

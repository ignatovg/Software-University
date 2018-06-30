using System;
using System.Collections.Generic;
using System.Text;

namespace P08_MilitaryElite.Contracts
{
   public interface IMission
    {
        string CodeName { get; }
        MissionState State { get; }
        void Complite();
    }
}

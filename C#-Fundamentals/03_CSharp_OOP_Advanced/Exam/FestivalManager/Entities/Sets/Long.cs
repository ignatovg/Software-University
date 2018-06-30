
using System;
using System.Collections.Generic;
using FestivalManager.Entities.Contracts;

namespace FestivalManager.Entities.Sets
{
    public class Long : Set
    {
        
        public override TimeSpan MaxDuration => new TimeSpan(0,0,60,0);

        public Long(string name) : base(name)
        {
        }
    }
}

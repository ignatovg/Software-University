using System.Collections.Generic;
using FestivalManager.Entities.Contracts;

namespace FestivalManager.Entities.Sets
{
	using System;

	public class Short : Set
	{
	    
	    public override TimeSpan MaxDuration => new TimeSpan(0,0,15,0);

	    public Short(string name) : base(name)
	    {
	    }
	}
}
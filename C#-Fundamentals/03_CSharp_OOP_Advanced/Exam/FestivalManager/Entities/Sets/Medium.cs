using System.Collections.Generic;
using FestivalManager.Entities.Contracts;

namespace FestivalManager.Entities.Sets
{
	using System;

	public class Medium : Set
	{
	     public override TimeSpan MaxDuration => new TimeSpan(0,0,40,0);


	    public Medium(string name) : base(name)
	    {
	    }
	}
}
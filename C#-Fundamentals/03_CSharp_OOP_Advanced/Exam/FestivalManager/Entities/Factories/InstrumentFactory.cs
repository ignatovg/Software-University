using System;
using System.Linq;
using System.Reflection;

namespace FestivalManager.Entities.Factories
{
	using Contracts;
	using Entities.Contracts;
	using Instruments;

	public class InstrumentFactory : IInstrumentFactory
	{
	    public IInstrument CreateInstrument(string type)
	    {
	        Type typeRef = Assembly.GetCallingAssembly().GetTypes()
	            .FirstOrDefault(t => t.Name == type);


	        if (typeRef == null)
	        {
	            throw new ArgumentException($"Cannot create instase of type {type}");
	        }

	        //if (!typeof(IInstrument).IsAssignableFrom(typeRef))
	        //{
	        //    throw new ArgumentException($"Cannot create instase of type {type}");

         //   }

	        return (IInstrument)Activator.CreateInstance(typeRef);
        }
	}
}
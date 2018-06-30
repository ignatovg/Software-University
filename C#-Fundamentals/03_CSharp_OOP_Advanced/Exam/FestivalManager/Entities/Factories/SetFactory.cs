using System;

using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;





namespace FestivalManager.Entities.Factories
{
	using Contracts;
	using Entities.Contracts;
	using Sets;

	public class SetFactory : ISetFactory
	{
	    public ISet CreateSet(string name, string type)
	    {
	        Type typeRef = Assembly.GetCallingAssembly().GetTypes()
	            .FirstOrDefault(t => t.Name == type);

	        if (typeRef == null)
	        {
	            throw new ArgumentException($"Cannot create instase of type {type}");
	        }

	        //if (!typeof(ISetFactory).IsAssignableFrom(typeRef))
	        //{
	        //    throw new ArgumentException($"Cannot create instase of type {type}");

	        //}

            return (ISet)Activator.CreateInstance(typeRef,name);
        }
	}




}

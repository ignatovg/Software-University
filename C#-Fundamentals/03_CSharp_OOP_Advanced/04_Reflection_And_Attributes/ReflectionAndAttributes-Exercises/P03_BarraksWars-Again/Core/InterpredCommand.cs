using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using _03BarracksFactory.Contracts;


public class CommandInterpreter : ICommandInterpreter
{
    private IRepository repository;
    private IUnitFactory unitFactory;

    public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
    {
        this.repository = repository;
        this.unitFactory = unitFactory;
    }

    public IExecutable InterpretCommand(string[] data, string commandName)
    {

        Assembly assembly = Assembly.GetCallingAssembly();
        Type commandType = assembly.GetTypes().FirstOrDefault(t => t.Name.ToLower() == commandName + "command");

        if (commandType == null)
        {
            throw new ArgumentException("Invalid command!");
        }

        if (!typeof(IExecutable).IsAssignableFrom(commandType))
        {
            throw new ArgumentException($"{commandName} Is not a Command!");
        }
        object[] constructorArgs = new object[] { data, repository, unitFactory };

        IExecutable instance = (IExecutable)Activator.CreateInstance(commandType, constructorArgs);

        return instance;
    }


}


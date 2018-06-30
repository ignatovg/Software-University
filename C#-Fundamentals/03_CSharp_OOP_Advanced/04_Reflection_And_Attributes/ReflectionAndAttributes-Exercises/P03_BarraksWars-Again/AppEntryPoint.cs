using System;
using System.Security.Authentication.ExtendedProtection;

namespace _03BarracksFactory
{
    using Contracts;
    using Core;
    using Core.Factories;
    using Data;
    using Microsoft.Extensions.DependencyInjection;
    class AppEntryPoint
    {
        static void Main(string[] args)
        {
            IServiceProvider serviceProvider = ConfigureServices();

            IRepository repository = new UnitRepository();
            IUnitFactory unitFactory = new UnitFactory();
            ICommandInterpreter commandInterpreter = new CommandInterpreter(repository,unitFactory);
            IRunnable engine = new Engine(commandInterpreter);
            engine.Run();                                      
        }

        private static IServiceProvider ConfigureServices()
        {

            //  IServiceCollection services = new ServiceCollection();
            // services.AddTransient<IUnitFactroty, UnitFactory>();
            // services.AddSingleton<IRepository, UnitRepository>();

            //IServiceProvider serviceProvider = services.BuildServiceProvider();
            //return serviceProvider;
        }

    }
}

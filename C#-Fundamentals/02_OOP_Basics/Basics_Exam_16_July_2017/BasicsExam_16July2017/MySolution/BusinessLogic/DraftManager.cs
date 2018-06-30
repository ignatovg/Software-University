using System;
using System.Collections.Generic;
using System.Linq;

public class DraftManager
{
    private HarvesterFactory harvesterFactory;
    private ProviderFactory providersFactory;

    private List<Harvester> harvesters;
    private List<Provider> providers;
    private string mode;
    private double totalEnergyStored;
    private double totalMinedOre;

    public DraftManager()
    {
        harvesterFactory = new HarvesterFactory();
        providersFactory = new ProviderFactory();

        harvesters = new List<Harvester>();
        providers = new List<Provider>();
        mode = "Full";
        totalEnergyStored = 0;
        totalMinedOre = 0;
    }

    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            Harvester harvester = harvesterFactory.CreateHarvester(arguments);
            harvesters.Add(harvester);
            return $"Successfully registered {harvester.Type} Harvester - {harvester.Id}";
        }
        catch (ArgumentException ae)
        {
            return ae.Message;
        }

    }
    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            Provider provider = providersFactory.CreateProvider(arguments);
            providers.Add(provider);
            return $"Successfully registered {provider.Type} Provider - {provider.Id}";
        }
        catch (ArgumentException ae)
        {
            return ae.Message;
        }
    }
    public string Day()
    {
        //possible bug
        totalEnergyStored += providers.Sum(p => p.EnergyOutput);
        double summedEnergyOutput;
        double summedOreOutput;
       
        if (mode == "Full")
        {
            summedEnergyOutput = harvesters.Sum(e => e.EnergyRequirement);
            summedOreOutput = harvesters.Sum(o => o.OreOutput);
        }
        else if (mode == "Half")
        {
            summedEnergyOutput = harvesters.Sum(e => e.EnergyRequirement) * 0.6;
            summedOreOutput = harvesters.Sum(o => o.OreOutput) * 0.5;
        }
        else 
        {
            summedEnergyOutput = 0;
            summedOreOutput = 0;
        }
      
        if (totalEnergyStored >= summedEnergyOutput)
        {
            totalEnergyStored -= summedEnergyOutput;
        }

        totalMinedOre += summedOreOutput;
        
        return $"A day has passed." + Environment.NewLine +
               $"Energy Provided: {summedEnergyOutput}" + Environment.NewLine +
               $"Plumbus Ore Mined: {summedOreOutput}";
    }
    public string Mode(List<string> arguments)
    {
        this.mode = arguments[0];

        return $"Successfully changed working mode to {mode} Mode";
    }
    public string Check(List<string> arguments)
    {
        var id = arguments[0];
        Unit unit = (Unit)providers.FirstOrDefault(p => p.Id == id) ?? harvesters.FirstOrDefault(h => h.Id == id);

        if (unit != null)
        {
            return unit.ToString();
        }
        else
        {
            return $"No element found with id - {id}";
        }
    }
    public string ShutDown()
    {
        return $"System Shutdown" + Environment.NewLine +
               $"Total Energy Stored: {totalEnergyStored}" + Environment.NewLine +
              $"Total Mined Plumbus Ore: {totalMinedOre}";

    }


}

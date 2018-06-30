using System;
using System.Collections.Generic;

public class TyreFactory
{
    public Tyre CreateTyre(List<string> commandArgs)
    {
        var tyreType = commandArgs[0];
        var tyreHardness = double.Parse(commandArgs[1]);

        switch (tyreType)
        {
            case "Ultrasoft":
                var grip = double.Parse(commandArgs[2]);
                return new UltrasoftTyre(tyreHardness,grip);
                
            case "Hard":
                return new HardTyre(tyreHardness);
            default:
                throw new ArgumentException("Invalid tyre type!");
        }
    }

   
    }
}


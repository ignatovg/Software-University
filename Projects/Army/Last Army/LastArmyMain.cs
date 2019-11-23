using System;
using System.Text;



public class LastArmyMain
{
    static void Main()
    {
       // Requirements - https://github.com/ignatovg/Software-University/blob/master/Projects/Army.docx

        var engine = new Engine(new ConsoleReader(), new ConsoleWriter());
        engine.Run();
         
    }
}
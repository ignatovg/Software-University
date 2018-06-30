using System;

public class ConsoleInputReader:IInputReader
{
    public string ReadLine()
    {
        return Console.ReadLine();
    }
}
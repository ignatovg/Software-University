using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private IInputReader inputReader;
    private IOutputWriter outputWriter;
    private HeroManager heroManager;

    public Engine(IInputReader inputReader, IOutputWriter outputWriter, HeroManager heroManager)
    {
        this.inputReader = inputReader;
        this.outputWriter = outputWriter;
        this.heroManager = heroManager;
    }

    public void Run()
    {
        bool isRunning = true;

        while (isRunning)
        {
            string inputLine = this.inputReader.ReadLine();
            List<string> arguments = this.ParseInput(inputLine);
            this.outputWriter.WriteLine(this.ProcessInput(arguments));
            isRunning = !this.ShouldEnd(inputLine);
        }
    }

    private List<string> ParseInput(string input)
    {
        return input.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    private string ProcessInput(List<string> arguments)
    {
        string command = arguments[0];
        arguments.RemoveAt(0);

        Type commandType = Type.GetType(command + "Command");
        var constructor = commandType.GetConstructor(new Type[] { typeof(IList<string>), typeof(IManager) });
        ICommand cmd = (ICommand)constructor.Invoke(new object[] { arguments, this.heroManager });
        return cmd.Execute();
    }

    private bool ShouldEnd(string inputLine)
    {
        return inputLine.Equals("Quit");
    }
}


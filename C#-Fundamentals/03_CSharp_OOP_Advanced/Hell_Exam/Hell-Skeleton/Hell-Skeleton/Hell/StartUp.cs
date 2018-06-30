public class StartUp
{
    public static void Main()
    {
        IInputReader inputReader = new ConsoleInputReader();
        IOutputWriter outputWriter = new ConsoleOutputWriter();
        HeroManager manager = new HeroManager();

        Engine engine = new Engine(inputReader, outputWriter, manager);
        engine.Run();
    }
}
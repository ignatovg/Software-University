namespace Logger_Exercise.Models.Contracts
{
    interface ILogFile
    {
        string Path { get; }

        int Size { get; }

        void WriteToFile(string errorLog);
    }
}

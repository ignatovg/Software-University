using Logger_Exercise.Models.Contracts;

namespace Logger_Exercise.Models.Factories
{
    internal class FileAppender : IAppender
    {
       
        private ILogFile logFile;

        public FileAppender(ILayout layout, ErrorLevel errorLevel, ILogFile logFile)
        {
            this.Layout = layout;
            this.Level = errorLevel;
            this.logFile = logFile;
            this.MessegesAppended = 0;
        }

        public ErrorLevel Level { get; }
        public ILayout Layout { get; }
        public  int MessegesAppended { get; private set; }

        public void Append(IError error)
        {
            string formattedError = this.Layout.FormatError(error);
            this.logFile.WriteToFile(formattedError);
            this.MessegesAppended++;
        }

        public override string ToString()
        {
            string appenderType = this.GetType().Name;
            string layoutType = this.Layout.GetType().Name;
            string level = this.Level.ToString();

            string result =
                $"Appender type: {appenderType}, Layout type: {layoutType}, Report level: {level}, Messages appended: {this.MessegesAppended}, File size: {this.logFile.Size}";

            return result;
        }
    }
}
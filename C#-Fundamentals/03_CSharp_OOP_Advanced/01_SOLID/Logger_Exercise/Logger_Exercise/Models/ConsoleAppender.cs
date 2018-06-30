using System;
using Logger_Exercise.Models.Contracts;

namespace Logger_Exercise.Models
{
    public class ConsoleAppender:IAppender
    {
        public ConsoleAppender(ILayout leLayout, ErrorLevel level)
        {
            this.Layout = leLayout;
            this.Level = level;
            this.MessegesAppended = 0;
        }

        public ErrorLevel Level { get; }

        public ILayout Layout { get; }

        public  int MessegesAppended { get; private set; }

        public void Append(IError error)
        {
            string formattedError = this.Layout.FormatError(error);
            Console.WriteLine(formattedError);
            this.MessegesAppended++;
        }

        public override string ToString()
        {
            string appenderType = this.GetType().Name;
            string layoutType = this.Layout.GetType().Name;
            string level = this.Level.ToString();

            string result =
                $"Appender type: {appenderType}, Layout type: {layoutType}, Report level: {level}, Messages appended: {this.MessegesAppended}";

            return result;
        }
    }
}

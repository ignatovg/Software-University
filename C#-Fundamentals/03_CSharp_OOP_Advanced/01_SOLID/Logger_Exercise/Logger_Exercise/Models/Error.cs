using System;
using Logger_Exercise.Models.Contracts;

namespace Logger_Exercise.Models
{
    class Error:IError
    {
        public Error(DateTime dateTime, ErrorLevel level, string messege)
        {
            this.DateTime = dateTime;
            this.Level = level;
            this.Messege = messege;
        }

        public ErrorLevel Level { get; }

        public DateTime DateTime { get; }

        public string Messege { get; }
    }
}

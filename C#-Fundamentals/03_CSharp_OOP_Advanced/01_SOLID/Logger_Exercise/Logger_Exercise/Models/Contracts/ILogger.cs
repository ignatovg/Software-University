using System.Collections.Generic;

namespace Logger_Exercise.Models.Contracts
{
    public interface ILogger
    {
        IReadOnlyCollection<IAppender> Appenders { get; }

        void Log(IError error);
    }

   
}

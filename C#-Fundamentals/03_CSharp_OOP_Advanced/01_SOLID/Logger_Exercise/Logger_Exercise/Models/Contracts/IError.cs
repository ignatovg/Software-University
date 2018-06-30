using System;

namespace Logger_Exercise.Models.Contracts
{
    public interface IError : ILevelable
    {
        DateTime DateTime { get; }

        string Messege { get; }
    }
}

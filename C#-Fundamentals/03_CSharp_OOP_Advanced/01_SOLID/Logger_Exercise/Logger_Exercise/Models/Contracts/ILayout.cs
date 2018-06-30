using System;
using System.Collections.Generic;
using System.Text;

namespace Logger_Exercise.Models.Contracts
{
    public interface ILayout
    {
        string FormatError(IError error);
    }
}

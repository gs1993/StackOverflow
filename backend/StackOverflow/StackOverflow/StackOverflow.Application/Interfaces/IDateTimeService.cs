using System;
using System.Collections.Generic;
using System.Text;

namespace StackOverflow.Application.Interfaces
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}

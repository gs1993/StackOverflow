using System;

namespace StackOverflow.Application.Interfaces.Utils
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}

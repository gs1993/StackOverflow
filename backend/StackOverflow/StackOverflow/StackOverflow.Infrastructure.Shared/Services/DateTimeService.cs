using StackOverflow.Application.Interfaces.Utils;
using System;

namespace StackOverflow.Infrastructure.Shared.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}

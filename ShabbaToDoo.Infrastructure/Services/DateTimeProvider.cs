using ShabbaToDoo.Application.Common.Interfaces.Services;

namespace ShabbaToDoo.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
using TechTestDDD.Application.Common.Interfaces.Services;

namespace TechTestDDD.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}

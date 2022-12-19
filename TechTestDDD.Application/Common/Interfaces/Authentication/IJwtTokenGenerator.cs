using TechTestDDD.Domain.Entities;

namespace TechTestDDD.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}

using TechTestDDD.Domain.Entities;

namespace TechTestDDD.Application.Authentication.Common
{
    public record AuthenticationResult(User User, string Token);
}

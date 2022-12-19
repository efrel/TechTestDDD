using TechTestDDD.Domain.Entities;

namespace TechTestDDD.Application.Services.Authentication
{
    public record AuthenticationResult(
        User User,
        string Token);
}

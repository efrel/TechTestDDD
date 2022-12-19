namespace TechTestDDD.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Guid Id, string firstName, string lastName);
    }
}

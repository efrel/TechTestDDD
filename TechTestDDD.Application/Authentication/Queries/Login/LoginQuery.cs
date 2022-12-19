using ErrorOr;
using MediatR;
using TechTestDDD.Application.Authentication.Common;

namespace TechTestDDD.Application.Authentication.Queries.Login
{
    public record LoginQuery(string Email, string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}

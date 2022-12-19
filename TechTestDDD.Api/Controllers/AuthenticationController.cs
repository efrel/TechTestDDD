using ErrorOr;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechTestDDD.Contracts.Authentication;
using TechTestDDD.Domain.Common.Errors;
using MediatR;
using TechTestDDD.Application.Authentication.Commands.Register;
using TechTestDDD.Application.Authentication.Common;
using TechTestDDD.Application.Authentication.Queries.Login;

namespace TechTestDDD.Api.Controllers
{
    [Route("api/auth")]
    public class AuthenticationController : ApiController
    {
        private readonly ISender _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = new RegisterCommand(request.FirstName,
                request.LastName,
                request.Email,
                request.Password);

            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

            return authResult.Match(
                authResult => Ok(MapResult(authResult)),
                errors => Problem(errors)
            );
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = new LoginQuery(request.Email, request.Password);
            ErrorOr<AuthenticationResult> authResult = await _mediator.Send(query);

            if(authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
            {
                return Problem(
                    statusCode: StatusCodes.Status401Unauthorized, 
                     title: authResult.FirstError.Description);
            }

            return authResult.Match(
                authResult => Ok(MapResult(authResult)),
                errors => Problem(errors)
            );
        }

        private static AuthenticationResponse MapResult(AuthenticationResult authResult)
        {
            return new AuthenticationResponse(
                authResult.User.Id,
                authResult.User.FirstName,
                authResult.User.LastName,
                authResult.User.Email,
                authResult.Token
            );
        }
    }
}

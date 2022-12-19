using ErrorOr;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechTestDDD.Contracts.Authentication;
using TechTestDDD.Domain.Common.Errors;
using MediatR;
using TechTestDDD.Application.Authentication.Commands.Register;
using TechTestDDD.Application.Authentication.Common;
using TechTestDDD.Application.Authentication.Queries.Login;
using Microsoft.AspNetCore.Authorization;
using MapsterMapper;

namespace TechTestDDD.Api.Controllers
{
    [Route("api/auth")]
    [AllowAnonymous]
    public class AuthenticationController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public AuthenticationController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Registra un nuevo usuario
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Si la petición es procesada correctamente se retorna la información del nuevo usuario.</returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            try
            {
                var command = _mapper.Map<RegisterCommand>(request);

                ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

                return authResult.Match(
                    authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                    errors => Problem(errors)
                );
            }
            catch(Exception ex)
            {
                return Problem(
                   statusCode: StatusCodes.Status400BadRequest,
                    title: ex.Message);
            }
        }

        /// <summary>
        /// Loguea al usuario
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Retorna la información del usuario con su token</returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            try
            {
                var query = _mapper.Map<LoginQuery>(request);
                ErrorOr<AuthenticationResult> authResult = await _mediator.Send(query);

                if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
                {
                    return Problem(
                        statusCode: StatusCodes.Status401Unauthorized,
                         title: authResult.FirstError.Description);
                }

                return authResult.Match(
                    authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                    errors => Problem(errors)
                );
            }
            catch(Exception ex)
            {
                return Problem(
                   statusCode: StatusCodes.Status400BadRequest,
                    title: ex.Message);
            }
        }
    }
}

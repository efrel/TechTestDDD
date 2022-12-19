using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTestDDD.Application.Common.Interfaces.Authentication;
using TechTestDDD.Application.Common.Interfaces.Persistence;
using TechTestDDD.Domain.Entities;
using TechTestDDD.Domain.Common.Errors;
using TechTestDDD.Application.Authentication.Common;

namespace TechTestDDD.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler : 
        IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(
            LoginQuery query, 
            CancellationToken cancellationToken)
        {
            // verifica si existe el usuario
            if (_userRepository.GetUserByEmail(query.Email) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            // validar que la contraseña es correcta
            if (user.Password != query.Password)
            {
                return Errors.Authentication.InvalidCredentials;
            }

            // crear Token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}

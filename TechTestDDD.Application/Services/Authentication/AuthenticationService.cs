using TechTestDDD.Application.Common.Interfaces.Authentication;
using TechTestDDD.Application.Common.Interfaces.Persistence;
using TechTestDDD.Domain.Entities;

namespace TechTestDDD.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public AuthenticationResult Login(string email, string password)
        {
            return new AuthenticationResult(
                Guid.NewGuid(),
                "firstName",
                "lastName",
                email,
                "token");
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            // verifica si existe el usuario
            if(_userRepository.GetUserByEmail(email) is not null)
            {
                throw new Exception("Usuario con ese correo ya existe.");
            }

            // crear un nuevo usuario
            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };

            _userRepository.Add(user);

            // crear JWT Token
            var token = _jwtTokenGenerator.GenerateToken(user.Id, firstName, lastName);

            return new AuthenticationResult(
                user.Id,
                firstName,
                lastName,
                email,
                token);
        }
    }
}

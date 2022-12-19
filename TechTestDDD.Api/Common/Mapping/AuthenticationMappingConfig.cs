using Mapster;
using TechTestDDD.Application.Authentication.Commands.Register;
using TechTestDDD.Application.Authentication.Common;
using TechTestDDD.Application.Authentication.Queries.Login;
using TechTestDDD.Contracts.Authentication;

namespace TechTestDDD.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>().MapToConstructor(true);
            config.NewConfig<LoginRequest, LoginQuery>().MapToConstructor(true);

            //config.NewConfig<RegisterCommand, RegisterRequest>();
            //config.NewConfig<LoginQuery, LoginRequest>();

            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(x => x, src => src.User)
                .MapToConstructor(true);
        }
    }
}

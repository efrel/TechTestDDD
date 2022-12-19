using Mapster;
using TechTestDDD.Application.Authentication.Commands.Register;
using TechTestDDD.Application.Authentication.Common;
using TechTestDDD.Application.Authentication.Queries.Login;
using TechTestDDD.Application.Vehicle.Common;
using TechTestDDD.Application.Vehicle.Queries.GetList;
using TechTestDDD.Contracts.Authentication;
using TechTestDDD.Contracts.Vehicle;

namespace TechTestDDD.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>().MapToConstructor(true);
            config.NewConfig<LoginRequest, LoginQuery>().MapToConstructor(true);

            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(x => x, src => src.User)
                .MapToConstructor(true);

            config.NewConfig<GetListRequest, GetListQuery>().MapToConstructor(true);

            config.NewConfig<VehicleResult, VehicleResponse>()
                .Map(x => x, src => src.Vehicle)
                .MapToConstructor(true);

            config.NewConfig<VehicleListResult, VehicleListResponse>()
                .Map(x => x, src => src.ListVehicle)
                .MapToConstructor(true);
        }
    }
}

using ErrorOr;
using MediatR;
using TechTestDDD.Application.Vehicle.Common;

namespace TechTestDDD.Application.Vehicle.Commands.DeleteVehicle
{
    public record DeleteVehicleCommand(int Id) : IRequest<ErrorOr<VehicleResult>>;
}

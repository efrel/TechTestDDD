using ErrorOr;
using MediatR;
using TechTestDDD.Application.Vehicle.Common;

namespace TechTestDDD.Application.Vehicle.Commands.DeleteVehicle
{
    public record UpdateVehicleCommand(Domain.Entities.Vehicle Vehicle) : IRequest<ErrorOr<VehicleResult>>;
}

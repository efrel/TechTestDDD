using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTestDDD.Application.Vehicle.Common;

namespace TechTestDDD.Application.Vehicle.Commands.InsertVehicle
{
    public record InsertVehicleCommand(Domain.Entities.Vehicle Vehicle) : IRequest<ErrorOr<VehicleResult>>;
}

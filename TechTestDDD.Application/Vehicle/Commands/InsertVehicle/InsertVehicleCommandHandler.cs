using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTestDDD.Application.Common.Interfaces.Persistence;
using TechTestDDD.Application.Vehicle.Common;
using TechTestDDD.Domain.Common.Errors;

namespace TechTestDDD.Application.Vehicle.Commands.InsertVehicle
{
    public class InsertVehicleCommandHandler :
        IRequestHandler<InsertVehicleCommand, ErrorOr<VehicleResult>>
    {
        private readonly IVehicleBasicRepository _vehicleBasicRepository;

        public InsertVehicleCommandHandler(IVehicleBasicRepository vehicleBasicRepository)
        {
            _vehicleBasicRepository = vehicleBasicRepository;
        }

        public async Task<ErrorOr<VehicleResult>> Handle(
            InsertVehicleCommand command, 
            CancellationToken cancellationToken)
        {
            if(command.Vehicle is not Domain.Entities.Vehicle vehicle)
                return Errors.Vehicle.Validation;

            var response = await _vehicleBasicRepository.CreateVehicle(command.Vehicle);

            return new VehicleResult(response);
        }
    }
}

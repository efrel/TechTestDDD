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

namespace TechTestDDD.Application.Vehicle.Commands.DeleteVehicle
{
    public class UpdateVehicleCommandHandler :
        IRequestHandler<UpdateVehicleCommand, ErrorOr<VehicleResult>>
    {
        private readonly IVehicleBasicRepository _vehicleBasicRepository;
        private readonly IVehicleAvanRepository _vehicleAvanRepository;

        public UpdateVehicleCommandHandler(
            IVehicleBasicRepository vehicleBasicRepository, 
            IVehicleAvanRepository vehicleAvanRepository)
        {
            _vehicleBasicRepository = vehicleBasicRepository;
            _vehicleAvanRepository = vehicleAvanRepository;
        }

        public async Task<ErrorOr<VehicleResult>> Handle(
            UpdateVehicleCommand command, 
            CancellationToken cancellationToken)
        {
            // valida si el campo tiene datos validados
            if (command.Vehicle is not Domain.Entities.Vehicle Vehicle)
                return Errors.Vehicle.Validation;

            // busca si existe el registro que desea modificar
            var response = await _vehicleBasicRepository.GetVehicleById(command.Vehicle.Id);

            if (response == null)
                return Errors.Vehicle.NotFound;

            // elimina el registro que corresponde al id enviado
            var updateRes = await _vehicleAvanRepository.UpdateVehicleById(command.Vehicle);

            return new VehicleResult(updateRes);
        }
    }
}

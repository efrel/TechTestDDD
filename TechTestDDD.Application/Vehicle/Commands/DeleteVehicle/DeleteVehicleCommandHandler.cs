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
    public class DeleteVehicleCommandHandler :
        IRequestHandler<DeleteVehicleCommand, ErrorOr<VehicleResult>>
    {
        private readonly IVehicleBasicRepository _vehicleBasicRepository;
        private readonly IVehicleAvanRepository _vehicleAvanRepository;

        public DeleteVehicleCommandHandler(
            IVehicleBasicRepository vehicleBasicRepository, 
            IVehicleAvanRepository vehicleAvanRepository)
        {
            _vehicleBasicRepository = vehicleBasicRepository;
            _vehicleAvanRepository = vehicleAvanRepository;
        }

        public async Task<ErrorOr<VehicleResult>> Handle(
            DeleteVehicleCommand command, 
            CancellationToken cancellationToken)
        {
            // valida si el campo tiene datos validados
            if (command.Id == 0)
                return Errors.Vehicle.Validation;

            // busca si existe el registro que desea eliminar.
            var response = await _vehicleBasicRepository.GetVehicleById(command.Id);

            if (response == null)
                return Errors.Vehicle.NotFound;

            // elimina el registro que corresponde al id enviado
            await _vehicleAvanRepository.DeleteVehicle(command.Id);

            return new VehicleResult(response);
        }
    }
}

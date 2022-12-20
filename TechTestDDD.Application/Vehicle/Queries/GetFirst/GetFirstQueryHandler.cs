using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTestDDD.Application.Common.Interfaces.Persistence;
using TechTestDDD.Application.Vehicle.Common;
using TechTestDDD.Application.Vehicle.Queries.GetFirst;
using TechTestDDD.Domain.Common.Errors;

namespace TechTestDDD.Application.Vehicle.Queries.GetList
{
    public class GetFirstQueryHandler :
        IRequestHandler<GetFirstQuery, ErrorOr<VehicleResult>>
    {
        private readonly IVehicleBasicRepository _vehicleBasicRepository;

        public GetFirstQueryHandler(IVehicleBasicRepository vehicleBasicRepository)
        {
            _vehicleBasicRepository = vehicleBasicRepository;
        }

        public async Task<ErrorOr<VehicleResult>> Handle(
            GetFirstQuery query, 
            CancellationToken cancellationToken)
        {
            if(query.Id == 0)
                return Errors.Vehicle.Validation;

            var response = await _vehicleBasicRepository.GetVehicleById(query.Id);

            if(response == null)
                return Errors.Vehicle.NotFound;

            return new VehicleResult(response);
        }
    }
}

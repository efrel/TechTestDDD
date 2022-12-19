using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTestDDD.Application.Common.Interfaces.Persistence;
using TechTestDDD.Application.Vehicle.Common;

namespace TechTestDDD.Application.Vehicle.Queries.GetList
{
    public class GetListQueryHandler :
        IRequestHandler<GetListQuery, ErrorOr<VehicleListResult>>
    {
        private readonly IVehicleBasicRepository _vehicleBasicRepository;

        public GetListQueryHandler(IVehicleBasicRepository vehicleBasicRepository)
        {
            _vehicleBasicRepository = vehicleBasicRepository;
        }

        public async Task<ErrorOr<VehicleListResult?>> Handle(
            GetListQuery query, 
            CancellationToken cancellationToken)
        {
            var list = await _vehicleBasicRepository.GetListVehicle();

            return new VehicleListResult(list);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTestDDD.Contracts.Vehicle
{
    public record VehicleListResponse(List<Domain.Entities.Vehicle>? ListVehicle);
}

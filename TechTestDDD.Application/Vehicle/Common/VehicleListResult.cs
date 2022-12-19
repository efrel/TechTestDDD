using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTestDDD.Application.Vehicle.Common
{
    public record VehicleListResult(List<Domain.Entities.Vehicle>? ListVehicle);
}

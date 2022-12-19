using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTestDDD.Contracts.Vehicle
{
    public record VehicleResponse(
        int Id,
        double Year,
        string County,
        double VehicleMiles,
        string Country,
        string State);
}

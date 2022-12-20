using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTestDDD.Contracts.Vehicle
{
    public record UpdateVehicleRequest(
        int Id,
        float Year,
        string County,
        float VehicleMiles,
        string Country,
        string State
    );
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTestDDD.Contracts.Vehicle
{
    public record InsertVehicleRequest(
        float Year,
        string County,
        float VehicleMiles,
        string Country,
        string State
    );
}

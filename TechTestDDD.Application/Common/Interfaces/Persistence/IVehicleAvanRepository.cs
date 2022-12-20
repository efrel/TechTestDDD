using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTestDDD.Domain.Entities;

namespace TechTestDDD.Application.Common.Interfaces.Persistence
{
    public interface IVehicleAvanRepository
    {
        Task DeleteVehicle(int Id);

        Task<Domain.Entities.Vehicle> UpdateVehicleById(Domain.Entities.Vehicle vehicle);
    }
}

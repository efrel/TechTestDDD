using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTestDDD.Domain.Entities;

namespace TechTestDDD.Application.Common.Interfaces.Persistence
{
    public interface IVehicleBasicRepository
    {
        Task<List<Domain.Entities.Vehicle>?> GetListVehicle();

        Task<Domain.Entities.Vehicle> GetVehicleById(int Id);

        Task<Domain.Entities.Vehicle> CreateVehicle(Domain.Entities.Vehicle vehicle);
    }
}

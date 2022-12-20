using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTestDDD.Application.Common.Interfaces.Persistence;
using TechTestDDD.Domain.Entities;

namespace TechTestDDD.Infrastructure.Persistence
{
    public class VehicleRepository : IVehicleBasicRepository, IVehicleAvanRepository
    {
        private readonly IDbConnection _dbConnection;

        public VehicleRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        
        public async Task<List<Vehicle>?> GetListVehicle()
        {
            var sql = @"SELECT Id
                  ,Year
                  ,County
                  ,VehicleMiles
                  ,Country
                  ,State
              FROM Vehicle_Miles_Traveled";

            var result = await _dbConnection.QueryAsync<Vehicle>(sql);

            return result.ToList();
        }

        public async Task<Vehicle?> GetVehicleById(int Id)
        {
            var sql = @"SELECT Id
                  ,Year
                  ,County
                  ,VehicleMiles
                  ,Country
                  ,State
              FROM Vehicle_Miles_Traveled
              WHERE Id = @Id";

            var result = await _dbConnection.QueryFirstOrDefaultAsync<Vehicle>(sql, new {Id = Id});

            return result;
        }

        public async Task<Vehicle> CreateVehicle(Vehicle vehicle)
        {
            var sql = @"INSERT INTO Vehicle_Miles_Traveled
                       (Year
                       ,County
                       ,VehicleMiles
                       ,Country
                       ,State)
                 VALUES
                       (@Year
                       ,@County
                       ,@VehicleMiles
                       ,@Country
                       ,@State)";

            var result = await _dbConnection.ExecuteAsync(sql, new {
                Year = vehicle.Year,
                County = vehicle.County,
                VehicleMiles = vehicle.VehicleMiles,
                Country = vehicle.Country,
                State = vehicle.State
            });

            return vehicle;
        }

        public async Task<Vehicle> UpdateVehicleById(Vehicle vehicle)
        {
            var sql = @"UPDATE Vehicle_Miles_Traveled
               SET Year = @Year
                  ,County = @County
                  ,VehicleMiles = @VehicleMiles
                  ,Country = @Country
                  ,State = @State
             WHERE Id = @Id";

            var result = await _dbConnection.ExecuteAsync(sql, new {
                Year = vehicle.Year, 
                County = vehicle.County, 
                VehicleMiles = vehicle.VehicleMiles, 
                Country = vehicle.Country, 
                State = vehicle.State,
                Id = vehicle.Id});

            return vehicle;
        }

        public async Task DeleteVehicle(int Id)
        {
            var sql = @"DELETE FROM Vehicle_Miles_Traveled
                  WHERE Id = @Id";

            var result = await _dbConnection.ExecuteAsync(sql, new { Id = Id });

        }
    }
}

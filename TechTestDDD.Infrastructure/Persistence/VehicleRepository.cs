using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
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
        private const string CONNECTION_STRING = @"Data Source=DESKTOP-7DGGBBM\SQLEXPRESS; Initial Catalog=TechTestDB;Integrated Security=True";
        
        public async Task<List<Vehicle>?> GetListVehicle()
        {
            var sql = @"SELECT Id
                  ,Year
                  ,County
                  ,VehicleMiles
                  ,Country
                  ,State
              FROM Vehicle_Miles_Traveled";

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                var result = await connection.QueryAsync<Vehicle>(sql);

                return result.ToList();
            }
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

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                var result = await connection.QueryFirstAsync<Vehicle>(sql, new {Id = Id});

                return result;
            }
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

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new {
                    Year = vehicle.Year,
                    County = vehicle.County,
                    VehicleMiles = vehicle.VehicleMiles,
                    Country = vehicle.Country
                });

                return vehicle;
            }
        }

        public async Task<Vehicle> UpdateVehicleById(Vehicle vehicle, int Id)
        {
            var sql = @"UPDATE [dbo].[Vehicle_Miles_Traveled]
               SET Year = @Year
                  ,County = @County
                  ,VehicleMiles = @VehicleMiles
                  ,Country = @Country
                  ,State = @State
             WHERE Id = @Id";

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new {
                    Year = vehicle.Year, 
                    County = vehicle.County, 
                    VehicleMiles = vehicle.VehicleMiles, 
                    Country = vehicle.Country, 
                    Id = Id});

                return vehicle;
            }
        }

        public async Task DeleteVehicle(int Id)
        {
            var sql = @"DELETE FROM Vehicle_Miles_Traveled
                  WHERE Id = @Id";

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = Id });

                //return result;
            }
        }
    }
}

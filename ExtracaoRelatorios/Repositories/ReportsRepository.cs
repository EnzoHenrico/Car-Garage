using System.Configuration;
using Dapper;
using Microsoft.Data.SqlClient;
using Models;

namespace Repositories
{
    public class ReportsRepository
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["MSSQL"].ConnectionString;

        public List<Car>? GetAllCars()
        {
            List<Car>? result;
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    result = connection.Query<Car>(Car.SelectAll).ToList();
                }

            }
            catch (SqlException databaseEx)
            {
                Console.WriteLine("DATABASE ERROR: " + databaseEx.Message);
                result = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                result = null;
            }
            return result;
        }

        public List<Service>? GetAllServices()
        {
            List<Service>? results;
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    results = connection.Query<Service>(Service.SelectAll).ToList();
                }
            }
            catch (SqlException databaseEx)
            {
                Console.WriteLine("DATABASE ERROR: " + databaseEx.Message);
                results = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                results = null;
            }
            return results;
        }

        public List<CarService>? GetAllCarServices()
        {
            List<CarService>? result = null;
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    result = connection.Query<CarService, Car, Service, CarService>(
                        CarService.SelectAll,
                        (carService, car, service) =>
                        {
                            carService.Car = car;
                            carService.Service = service;
                            return carService;
                        }
                    ).ToList();
                }
            }
            catch (SqlException databaseEx)
            {
                Console.WriteLine("DATABASE ERROR: " + databaseEx.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                throw;
            }
            return result;
        }
    }
}

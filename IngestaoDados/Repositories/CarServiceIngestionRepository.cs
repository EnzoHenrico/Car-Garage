using Dapper;
using Microsoft.Data.SqlClient;
using Models;

namespace Repositories
{
    public class CarServiceIngestionRepository
    {
        private readonly SqlConnection _sqlConnection = new MsSqlDatabase().Connection;

        public int InsertOne(CarService carService)
        {
            int id;
            try
            {
                _sqlConnection.Open();
                id = _sqlConnection.QuerySingle<int>(CarService.InsertOne, new
                {
                    CarPlate = carService.Car.Plate,
                    ServiceId = carService.Service.Id,
                    Status = carService.Status ? 1 : 0
                });
            }
            catch (SqlException databaseEx)
            {
                Console.WriteLine("DATABASE ERROR: " + databaseEx.Message);
                id = 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                id = 0;
            }
            finally
            {
                _sqlConnection.Close();
            }
            return id;
        }

        public List<CarService>? SelectAll()
        {
            List<CarService> queryResult;
            try
            {
                _sqlConnection.Open();
                queryResult = _sqlConnection.Query<CarService>(CarService.SelectAll).ToList();
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
            finally
            {
                _sqlConnection.Close();
            }
            return queryResult;
        }
    }
}

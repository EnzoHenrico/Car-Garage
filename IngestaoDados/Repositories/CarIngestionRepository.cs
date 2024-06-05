using System.Data.SqlClient;
using Dapper;
using Models;

namespace Repositories
{
    public class CarIngestionRepository : IDataIgestionRepository
    {
        private readonly SqlConnection _sqlConnection = new MsSqlDatabase().Connection;

        public string InsertOne(Car car)
        {
            var carPlate = string.Empty;
            try
            {
                _sqlConnection.Open();
                carPlate = _sqlConnection.ExecuteScalar<string>(Car.InsertOne, car);
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
            return carPlate;
        }
    }
}

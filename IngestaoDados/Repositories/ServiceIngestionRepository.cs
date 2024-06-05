using Models;
using System.Data.SqlClient;
using Dapper;

namespace Repositories
{
    public class ServiceIngestionRepository : IDataIgestionRepository
    {
        private readonly SqlConnection _sqlConnection = new MsSqlDatabase().Connection;

        public int InsertOne(Service service)
        {
            var id = 0;
            try
            {
                _sqlConnection.Open();
                id = _sqlConnection.ExecuteScalar<int>(Service.InsertOne, service);
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
            return id;
        }
    }
    
}

using Dapper;
using Microsoft.Data.SqlClient;
using Models;

namespace Repositories
{
    public class ServiceIngestionRepository
    {
        private readonly SqlConnection _sqlConnection = new MsSqlDatabase().Connection;

        public int InsertOne(Service service)
        {
            int id;
            try
            {
                _sqlConnection.Open();
                id = _sqlConnection.QuerySingle<int>(Service.InsertOne, service);
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

        public List<Service>? SelectAll()
        {
            List<Service> queryResult;
            try
            {
                _sqlConnection.Open();
                queryResult = _sqlConnection.Query<Service>(Service.SelectAll).ToList();
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

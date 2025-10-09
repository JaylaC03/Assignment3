using Npgsql;

namespace ClassLibrary1
{
    public class PostgresConnector : IDBConnector
    {
        private string connectionString;

        public PostgresConnector(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool Ping()
        {
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
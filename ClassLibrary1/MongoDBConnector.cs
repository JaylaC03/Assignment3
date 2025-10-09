using MongoDB.Driver;

namespace ClassLibrary1
{
    public class MongoDBConnector : IDBConnector
    {
        private MongoClient client;

        public MongoDBConnector(string connectionString)
        {
            client = new MongoClient(connectionString);
        }
        public bool Ping()
        {
            // not implemented yet
            return false;
        }
    }
}

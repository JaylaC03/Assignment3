using MongoDB.Driver;

namespace ClassLibrary1
{
    public class MongoDBConnector
    {
        private MongoClient client;

        public MongoDBConnector(string connectionString)
        {
            client = new MongoClient(connectionString);
        }
    }
}

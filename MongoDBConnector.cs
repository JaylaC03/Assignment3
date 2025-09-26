using MongoDB.Driver;
using MongoDB.Bson;

namespace ClassLibrary1
{
    public class MongoDBConnector
    {
        private MongoClient client;

        public MongoDBConnector(string connectionString)
        {
            client = new MongoClient(connectionString);
        }

        public bool Ping()
        {
            try
            {
                var database = client.GetDatabase("admin");
                var command = new BsonDocument("ping", 1);
                database.RunCommand<BsonDocument>(command);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

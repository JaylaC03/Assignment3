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
                database.RunCommand<MongoDB.Bson.BsonDocument>("{ ping: 1 }");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
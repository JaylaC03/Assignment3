using Testcontainers.MongoDb;
using Xunit;
using ClassLibrary1;

namespace TestProject1
{
    public class MongoDBConnectorTest
    {
        [Fact]
        public async Task TestPingSuccess()
        {
            var container = new MongoDbBuilder().Build();
            await container.StartAsync();

            var connector = new MongoDBConnector(container.GetConnectionString());

            bool result = connector.Ping();

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(result);

            await container.DisposeAsync();
        }
    }
}
using ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class PostgresConnectorTests
    {
        [TestMethod]
        public void Ping_WithValidConnection_ReturnsTrue()
        {
            // Arrange
            string connectionString = "Host=localhost;Port=5432;Database=testdb;Username=postgres;Password=password";
            var connector = new PostgresConnector(connectionString);

            // Act
            bool result = connector.Ping();

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsTrue(result);
        }

        [TestMethod]
        public void Ping_WithInvalidConnection_ReturnsFalse()
        {
            // Arrange
            string connectionString = "Host=invalid;Port=5432;Database=testdb;Username=postgres;Password=wrong";
            var connector = new PostgresConnector(connectionString);

            // Act
            bool result = connector.Ping();

            // Assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsFalse(result);
        }
    }
}
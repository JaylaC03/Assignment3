using Testcontainers.MongoDb;

namespace DatabaseLibrary.Tests;

public class MongoDBConnectorTests : IAsyncLifetime
{
    private MongoDbContainer _mongoContainer = null!;

    public async Task InitializeAsync()
    {
        _mongoContainer = new MongoDbBuilder().Build();
        await _mongoContainer.StartAsync();
    }

    public async Task DisposeAsync()
    {
        await _mongoContainer.DisposeAsync();
    }

    [Fact]
    public void Ping_WithValidConnection_ReturnsTrue()
    {
        // Arrange
        var connectionString = _mongoContainer.GetConnectionString();
        var connector = new MongoDBConnector(connectionString);

        // Act
        var result = connector.Ping();

        // Assert
        Assert.True(result);
    }
}
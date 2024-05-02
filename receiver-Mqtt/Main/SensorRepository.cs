using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Abstractions;
using System.Data;

namespace NetCoreClient;

internal class SensorRepository
{
    private readonly ILogger<SensorRepository> _logger;
    private readonly string _connectionString;      //usersecret

    public SensorRepository(ILogger<SensorRepository> logger, IConfiguration configuration)
    {
        _logger = logger;
        _connectionString = configuration.GetConnectionString("db");
    }

    //#########################################################################
    public async Task InsertAsync(SensorData speed)
    {
        DbSpeed dbSpeed = new()
        {
            _topicId = speed._topicId,
            _speed = speed._speed,
            _sentDateTime = speed._sentDateTime,
            _receivedDateTime = speed._receivedDateTime
        };

        const string query = """
            INSERT INTO [dbo].[fantinBianciFioriSpeed](
                    [topicId],
                    [speed],
                    [sentDateTime],
                    [receivedDateTime])
            VALUES(
                    @_topicId,
                    @_speed,
                    @_sentDateTime,
                    @_receivedDateTime);
            """;

        using var connection = new SqlConnection(_connectionString);
        await connection.ExecuteAsync(query, dbSpeed);
        _logger.LogInformation($"Data inserted at: {DateTimeOffset.Now}");
    }

    private class DbSpeed
    {
        public string _topicId { get; set; }
        public int _speed { get; set; }
        public DateTime _sentDateTime { get; set; }
        public DateTime _receivedDateTime {  get; set; }
    }
}



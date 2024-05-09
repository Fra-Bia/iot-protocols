using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System.Globalization;
using System.Text;

namespace NetCoreClient.Protocols;
internal class Amqp : IProtocolInterface
{
    private readonly ConnectionFactory _factory;
    private IConnection _connection;
    private IModel _channel;

    public Amqp(string host, string user, string vHost, string psw)
    {

        _factory = new ConnectionFactory { HostName = host, UserName = user, VirtualHost = vHost, Password = psw };
        OpenConnection();
    }

    private void OpenConnection()
    {
        _connection = _factory.CreateConnection();
        _channel = _connection.CreateModel();
    }

    public void Send(string data, string sensor)
    {
        DeclareQueue();
        string message = data;
        var body = Encoding.UTF8.GetBytes(message);
        PublishMessage(body);
        Console.WriteLine($" [x] Sent {message}");
    }

    private void DeclareQueue()
    {
        _channel.QueueDeclare(queue: "queue",
                             durable: false,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);
    }

    private void PublishMessage(byte[] body)
    {
        _channel.BasicPublish(exchange: string.Empty,
                              routingKey: "queue",
                              basicProperties: null,
                              body: body);
    }

    public void CloseConnection()
    {
        _channel.Close();
        _connection.Close();
    }
}


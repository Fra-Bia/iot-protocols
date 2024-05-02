using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

public class RabbitMQReceiver
{
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public RabbitMQReceiver(string host, string user, string vHost, string psw)
    {
        var factory = new ConnectionFactory { HostName = host, UserName = user, VirtualHost = vHost, Password = psw };
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
    }

    public void StartReceiving(string queueName)
    {
        _channel.QueueDeclare(queue: queueName,
                              durable: false,
                              exclusive: false,
                              autoDelete: false,
                              arguments: null);

        Console.WriteLine(" [*] Waiting for messages.");

        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine($" [x] Received {message}");
        };
        _channel.BasicConsume(queue: queueName,
                              autoAck: true,
                              consumer: consumer);
    }

    public void CloseConnection()
    {
        _channel.Close();
        _connection.Close();
    }
}


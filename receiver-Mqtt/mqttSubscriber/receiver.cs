using System;
using System.Text;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;

namespace NetCoreClient.Protocols
{
    public class MqttSubscriber
    {
        private const string TOPIC_PREFIX = "iot2024/";
        private IMqttClient _mqttClient;
        private string _endpoint;
        private int _port;
        private string _clientId;

        public MqttSubscriber(string endpoint, int port, string clientId)
        {
            _endpoint = endpoint;
            _port = port;
            _clientId = clientId;

            Initialize().GetAwaiter().GetResult();
        }

        private async Task Initialize()
        {
            var factory = new MqttFactory();

            var options = new MqttClientOptionsBuilder()
                .WithTcpServer(_endpoint, _port)
                .WithClientId(_clientId)
                .WithCleanSession()
                .Build();

            _mqttClient = factory.CreateMqttClient();

            _mqttClient.ApplicationMessageReceivedAsync += e =>
            {
                var message = e.ApplicationMessage;
                Console.WriteLine($"Received message from topic: {message.Topic}");
                Console.WriteLine($"Payload: {Encoding.UTF8.GetString(message.Payload)}");
                return Task.CompletedTask;
            };

            await _mqttClient.ConnectAsync(options);
        }

        public async Task Subscribe(string sensor)
        {
            var topic = TOPIC_PREFIX + sensor;

            await _mqttClient.SubscribeAsync(new MqttTopicFilterBuilder().WithTopic(topic).Build());
        }

        public async Task Unsubscribe(string sensor)
        {
            var topic = TOPIC_PREFIX + sensor;

            await _mqttClient.UnsubscribeAsync(topic);
        }
    }
}

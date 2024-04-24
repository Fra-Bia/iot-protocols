using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Main;
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

        private SensorRepository _repo = new();

        public MqttSubscriber(string endpoint, int port, string clientId)
        {
            _endpoint = endpoint;
            _port = port;
            _clientId = clientId;

            Console.Write("GGWP");
            Initialize().GetAwaiter().GetResult();
        }

        private async Task Initialize()
        {


            Console.Write("GGWP1");
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
                var msg = Encoding.UTF8.GetString(message.PayloadSegment);
                Console.WriteLine($"Received message from topic: {message.Topic}");
                Console.WriteLine($"Payload: {msg}");

                //######################################################

                SpeedData speedData = JsonSerializer.Deserialize<SpeedData>(msg) ?? throw new Exception("impossibile deserializzare");

                SensorData speed = new()
                {
                    _topicId = message.Topic,                
                    _speed = speedData._value,
                    _receivedDateTime = DateTime.Now,
                    _sentDateTime = speedData._dateTime
                };
                
                //#####################################################
                
                return _repo.InsertAsync(speed);
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
        public bool IsConnected()
        {
            return _mqttClient.IsConnected;
        }
        
    }
}

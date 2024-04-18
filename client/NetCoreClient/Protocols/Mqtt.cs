using MQTTnet;
using MQTTnet.Client;

namespace NetCoreClient.Protocols
{
    internal class Mqtt : IProtocolInterface
    {
        private const string TOPIC_PREFIX = "iot2024/Fantin/";
        private IMqttClient mqttClient;
        private string _endpoint;    //BrokerAdress

        public Mqtt(string endpoint)
        {
            _endpoint = endpoint;

            Connect().GetAwaiter().GetResult();
        }
        /// <summary>
        /// Creates MQTT Client wit specified endpoint and Connects
        /// </summary>
        /// <returns></returns>
        private async Task<MqttClientConnectResult> Connect()
        {
            var factory = new MqttFactory();

            var options = new MqttClientOptionsBuilder()
                .WithTcpServer(_endpoint)
                .Build();

            mqttClient = factory.CreateMqttClient();

            return await mqttClient.ConnectAsync(options, CancellationToken.None);
        }

        /// <summary>
        /// Builds the message with the data from sensors, adds the device to the topic to wich publishes, sets the QoS; then sends the message
        /// </summary>
        /// <param name="data"></param>
        /// <param name="sensor"></param>
        public async void Send(string data, string sensor)
        {
            var message = new MqttApplicationMessageBuilder()
                .WithTopic(TOPIC_PREFIX + sensor)
                .WithPayload(data)
                .WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.ExactlyOnce)
                .Build();

            await mqttClient.PublishAsync(message, CancellationToken.None);
        }
    }
}

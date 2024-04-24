using NetCoreClient.Protocols;

string endpoint = "test.mosquitto.org";
int port = 1883;
string clientId = Guid.NewGuid().ToString();
string topicGeneral = "#";
string topicFantin = "/Fantin/speed";


var subscriber = new MqttSubscriber(endpoint, port, clientId);

if (subscriber.IsConnected())
{
    Console.WriteLine("Connected");
}
else
{
    Console.WriteLine("Failed to connect");
}

await subscriber.Subscribe(topicGeneral);

while (true) { }

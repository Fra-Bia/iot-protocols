using NetCoreClient.Sensors;
using NetCoreClient.Protocols;

// define sensors -- aggiungo/tolgo sensori per l'invio dati
List<ISensorInterface> sensors = new();
sensors.Add(new VirtualSpeedSensor());
//sensors.Add(new VirtualPositionSensor());

// define protocol -- definisco il protocollo per l'invio dei dati (http, mqtt, ecc..)
//IProtocolInterface protocol = new Http("http://localhost:8011/cars/123");
IProtocolInterface protocol = new Mqtt("test.mosquitto.org");

// send data to server
while (true)
{
    foreach (ISensorInterface sensor in sensors)
    {
        var sensorValue = sensor.ToJson();

        protocol.Send(sensorValue, sensor.GetSlug());

        Console.WriteLine("Data sent: " + sensorValue);

        Thread.Sleep(5000);
    }

}
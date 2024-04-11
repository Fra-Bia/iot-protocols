using NetCoreClient.Sensors;
using NetCoreClient.Protocols;

// define sensors -- aggiungo/tolgo sensori
List<ISensorInterface> sensors = new();
sensors.Add(new VirtualSpeedSensor());
sensors.Add(new VirtualPositionSensor());

// define protocol -- definisco il protocollo per l'invio dei dati (http, mqtt, ecc..)
ProtocolInterface protocol = new Http("https://891d-185-122-225-105.ngrok-free.app/cars/123");

// send data to server
while (true)
{
    foreach (ISensorInterface sensor in sensors)
    {
        var sensorValue = sensor.ToJson();

        protocol.Send(sensorValue);

        Console.WriteLine("Data sent: " + sensorValue);

        Thread.Sleep(5000);
    }

}
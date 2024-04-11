using System.Text.Json;

namespace NetCoreClient.Sensors;

class VirtualDoorSensor : IDoorSensorInterface, ISensorInterface
{
    private readonly string doorLock;

    public VirtualDoorSensor()
    {
        doorLock = new Random().Next(2) == 0 ? "Yes" : "No";
    }

    public string DoorLock()
    {
        return doorLock;
    }

    public string ToJson()
    {
        return JsonSerializer.Serialize(DoorLock());
    }
}
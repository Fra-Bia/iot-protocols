using NetCoreClient.ValueObjects;
using System.Text.Json;

namespace NetCoreClient.Sensors;

class VirtualDoorSensor : IDoorSensorInterface, ISensorInterface
{
    private readonly string doorOpen;
    private readonly string doorLock;

    public VirtualDoorSensor()
    {
        doorOpen = new Random().Next(2) == 0 ? "Yes" : "No";
        //doorLock = new Random().Next(2) == 0 ? "Yes" : "No";
        doorLock = "Yes";
    }

    public CarDoors GetDoorStatus()
    {
        return new CarDoors(doorOpen, doorLock);
    }

    public string ToJson()
    {
        return JsonSerializer.Serialize(GetDoorStatus());
    }
    public string GetSlug()
    {
        return "door";
    }
}
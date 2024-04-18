using NetCoreClient.ValueObjects;

namespace NetCoreClient.Sensors
{
    interface IDoorSensorInterface
    {
        CarDoors GetDoorStatus();
    }
}
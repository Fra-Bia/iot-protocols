using NetCoreClient.ValueObjects;
using System.Text.Json;

namespace NetCoreClient.Sensors
{
    class VirtualSpeedSensor : ISpeedSensorInterface, ISensorInterface
    {
        private readonly Random Random;

        public VirtualSpeedSensor()
        {
            Random = new Random();
        }

        public Speed GetSpeed()
        {
            return new Speed(Random.Next(100));
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(GetSpeed());
        }

        public string GetSlug()
        {
            return "speed";
        }
    }
}

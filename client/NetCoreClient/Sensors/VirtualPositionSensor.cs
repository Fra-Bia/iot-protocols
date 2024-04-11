using NetCoreClient.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NetCoreClient.Sensors;

class VirtualPositionSensor : ISensorInterface, IPositionSensorInterface
{
    private readonly Random Random;

    public VirtualPositionSensor()
    {
        Random = new Random();
    }

    public Position Position()
    {
        return new Position(Random.Next(50), Random.Next(100));
    }

    public string ToJson()
    {
        return JsonSerializer.Serialize(Position());
    }
}

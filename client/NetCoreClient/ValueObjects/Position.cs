namespace NetCoreClient.ValueObjects;

public class Position
{
    public int ValueLat { get; private set; }
    public int ValueLon { get; private set; }

    public Position(int lat, int lon)
    {
        this.ValueLat = lat;
        this.ValueLon = lon;
    }
}

namespace NetCoreClient.ValueObjects;

public class Position
{
    public int _valueLat { get; private set; }
    public int _valueLon { get; private set; }

    public Position(int lat, int lon)
    {
        _valueLat = lat;
        _valueLon = lon;
    }
}

namespace NetCoreClient;

public class SensorData
{
    public string _topicId { get; set; }
    public int _speed { get; set; }
    public DateTime _sentDateTime { get; set; }
    public DateTime _receivedDateTime { get; set; } = DateTime.Now;
}

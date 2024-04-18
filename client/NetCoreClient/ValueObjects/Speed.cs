namespace NetCoreClient.ValueObjects
{
    internal class Speed
    {
        public int _value { get; private set; }
        public DateTime _dateTime { get; private set; }
        public Speed(int value)
        {
            _value = value;
            _dateTime = DateTime.Now;
        }

    }
}

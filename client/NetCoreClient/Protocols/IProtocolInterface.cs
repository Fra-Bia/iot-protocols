namespace NetCoreClient.Protocols
{
    internal interface IProtocolInterface
    {
        void Send(string data, string sensor);
    }
}
namespace BusClient.Lib
{
    public interface IBusClient
    {
        void Publish<TMessage>(TMessage message);
        void Subscribe<TMessage>();
    }
}

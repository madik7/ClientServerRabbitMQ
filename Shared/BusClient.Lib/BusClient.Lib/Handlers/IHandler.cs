
namespace BusClient.Lib.Handlers
{
    public interface IHandler<TMessage>
    {
        void Handle(TMessage message);
    }
}

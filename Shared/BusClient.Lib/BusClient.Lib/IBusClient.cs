using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusClient.Lib
{
    public interface IBusClient
    {
        void Publish<TMessage>(TMessage message);
        void Subscribe<TMessage>();
    }
}

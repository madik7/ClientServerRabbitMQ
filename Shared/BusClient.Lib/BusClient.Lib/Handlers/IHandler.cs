using System;
using System.Collections.Generic;
using System.Text;

namespace BusClient.Lib.Handlers
{
    public interface IHandler<TMessage>
    {
        void Handle(TMessage message);
    }
}

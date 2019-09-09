using Rationals;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Server.Application.Services
{
    public interface IPiService
    {
        string Calculate(int precision, CancellationToken cancellationToken);
    }
}

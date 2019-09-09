using System.Threading;

namespace Server.Application.Services
{
    public interface IPiService
    {
        string Calculate(int precision, CancellationToken cancellationToken);
    }
}

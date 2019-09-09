using Server.Domain;

namespace Server.Application.Services
{
    public interface IJobService
    {
        void Complete(Job job);
    }
}

using Server.Domain;

namespace Server.Application.Services
{
    public interface IJobManager
    {
        void AddJob(Job job);
        void CancelJob(string id);
        void CancelAllJobs();
        Job GetJob();
        void RemoveJob(Job job);
    }
}

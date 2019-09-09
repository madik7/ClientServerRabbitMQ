using System.Collections.Generic;
using System.Linq;
using Server.Domain;

namespace Server.Application.Services
{
    public class JobManager : IJobManager
    {
        private readonly List<Job> _jobs = new List<Job>();
        private readonly IJobService _service;
        public JobManager(IJobService service)
        {
            _service = service;
        }

        public void AddJob(Job job)
        {
            _jobs.Add(job);
        }

        public void CancelAllJobs()
        {
            _jobs.ForEach(x =>
            {
                x.CancellationTokenSource.Cancel();
            });
        }

        public void CancelJob(string id)
        {
            var job = _jobs.Where(x => x.Id == id).FirstOrDefault();
            if (job != null)
            {
                job.CancellationTokenSource.Cancel();
                _service.Complete(job);
                RemoveJob(job);
            }
        }

        public Job GetJob()
        {
            return _jobs.FirstOrDefault();
        }

        public void RemoveJob(Job job)
        {
            _jobs.Remove(job);
        }
    }
}

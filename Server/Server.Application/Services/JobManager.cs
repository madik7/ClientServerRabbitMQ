using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Domain;

namespace Server.Application.Services
{
    public class JobManager : IJobManager
    {
        //private readonly ConcurrentDictionary<string,Job> _jobs = new ConcurrentDictionary<string,Job>();
        private readonly List<Job> _jobs = new List<Job>();
        public JobManager()
        {

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
      //      _jobs.Clear();
        }

        public void CancelJob(string id)
        {
            var job = _jobs.Where(x => x.Id == id).FirstOrDefault();
            if (job != null)
            {
                job.CancellationTokenSource.Cancel();
          //      _jobs.Remove(job);
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

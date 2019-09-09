using Server.Domain;
using System;
using System.Collections.Generic;
using System.Text;

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

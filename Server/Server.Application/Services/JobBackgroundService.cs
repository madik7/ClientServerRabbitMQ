using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server.Application.Services
{
    public class JobBackgroundService : BackgroundService
    {
        private readonly IJobManager _manager;
        private readonly IJobService _service;

        public JobBackgroundService(IJobManager manager, IJobService service)
        {
            _manager = manager;
            _service = service;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var job = _manager.GetJob();
                if (job != null)
                {
                    await Task.Run(() => _service.Complete(job));
                    _manager.RemoveJob(job);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using BusClient.Lib;
using Server.Domain;
using Server.Domain.Messages;

namespace Server.Application.Services
{
    public class JobService : IJobService
    {
        private readonly IPiService _service;
        private readonly IMapper _mapper;
        private readonly IBusClient _client;

        public JobService(IPiService service, IMapper mapper, IBusClient client)
        {
            _service = service;
            _mapper = mapper;
            _client = client;
        }

        public void Complete(Job job)
        {
            try
            {
                job.Result = _service.Calculate(job.Precision, job.CancellationTokenSource.Token);
            }catch(Exception ex)
            {

            }
            var jobCompletedMessage = _mapper.Map<JobCompletedMessage>(job);
            _client.Publish(jobCompletedMessage);
        }
    }
}

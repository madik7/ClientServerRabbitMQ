using AutoMapper;
using BusClient.Lib.Handlers;
using Server.Application.Services;
using Server.Domain;
using Server.Domain.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Application.Handlers
{
    public class JobCreatedHandler : IHandler<JobCreatedMessage>
    {
        private readonly IMapper _mapper;
        private readonly IJobManager _manager;

        public JobCreatedHandler(IMapper mapper, IJobManager manager)
        {
            _mapper = mapper;
            _manager = manager;
        }

        public void Handle(JobCreatedMessage message)
        {
            var job = _mapper.Map<Job>(message);
            _manager.AddJob(job);

        }
    }
}

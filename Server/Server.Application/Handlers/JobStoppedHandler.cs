using AutoMapper;
using BusClient.Lib.Handlers;
using Server.Application.Services;
using Server.Domain.Messages;

namespace Server.Application.Handlers
{
    public class JobStoppedHandler : IHandler<JobStoppedMessage>
    {
        private readonly IMapper _mapper;
        private readonly IJobManager _manager;

        public JobStoppedHandler(IMapper mapper, IJobManager manager)
        {
            _mapper = mapper;
            _manager = manager;
        }

        public void Handle(JobStoppedMessage message)
        {
            if (string.IsNullOrEmpty(message.Id))
                _manager.CancelAllJobs();
            else
                _manager.CancelJob(message.Id);
        }
    }
}

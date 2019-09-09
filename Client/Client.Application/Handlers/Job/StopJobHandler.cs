using AutoMapper;
using BusClient.Lib;
using Client.Domain.Messages;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Client.Application.Handlers.Job
{
    public class StopJobHandler : IRequestHandler<StopJobDto>
    {
        private readonly IMapper _mapper;
        private readonly IBusClient _client;

        public StopJobHandler(IMapper mapper, IBusClient client)
        {
            _mapper = mapper;
            _client = client;
        }

        public Task<Unit> Handle(StopJobDto stopJobDto, CancellationToken cancellationToken)
        {
            var jobStoppedMessage = _mapper.Map<JobStoppedMessage>(stopJobDto);

            _client.Publish(jobStoppedMessage);
        
            return Task.FromResult(new Unit());
        }
    }
}

using AutoMapper;
using BusClient.Lib;
using Client.Domain.Messages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client.Application.Handlers.Job
{
    public class CreateJobHandler : IRequestHandler<CreateJobDto, string>
    {
        private readonly IMapper _mapper;
        private readonly IBusClient _client;

        public CreateJobHandler(IMapper mapper, IBusClient client)
        {
            _mapper = mapper;
            _client = client;
        }

        public async Task<string> Handle(CreateJobDto createJobDto, CancellationToken cancellationToken)
        {
            var validator = new CreateJobDtoValidator();
            await validator.ValidateAsync(createJobDto);

            var jobCreatedMessage = _mapper.Map<JobCreatedMessage>(createJobDto);
            jobCreatedMessage.Id = Guid.NewGuid().ToString();

            //send
            _client.Publish(jobCreatedMessage);


            return jobCreatedMessage.Id;
        }
    }
}

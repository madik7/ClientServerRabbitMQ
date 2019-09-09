using BusClient.Lib.Handlers;
using Client.Domain.Messages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Application.Handlers.Job
{
    public class JobCompletedHandler : IHandler<JobCompletedMessage>
    {
        private readonly ILogger<JobCompletedHandler> _logger;

        public JobCompletedHandler(ILogger<JobCompletedHandler> logger)
        {
            _logger = logger;
        }

        public void Handle(JobCompletedMessage message)
        {
            _logger.LogInformation($"Job (id:{message.Id}) Completed! Result: {message.Result}");
        }
    }
}

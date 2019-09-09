using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Application.Handlers.Job
{
    public class StopJobDto : IRequest
    {
        public string Id { get; set; }
    }
}

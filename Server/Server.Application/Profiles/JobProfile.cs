using AutoMapper;
using Server.Domain;
using Server.Domain.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Application.Profiles
{
    public class JobProfile : Profile
    {
      public JobProfile()
        {
            CreateMap<JobCreatedMessage, Job>();
            CreateMap<Job, JobCompletedMessage>();
        }
    }
}

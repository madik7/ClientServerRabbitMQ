using AutoMapper;
using Client.Application.Handlers.Job;
using Client.Domain.Messages;

namespace Client.Application.Profiles
{
    public class JobProfiles : Profile
    {
        public JobProfiles()
        {
            CreateMap<CreateJobDto, JobCreatedMessage>();
            CreateMap<StopJobDto, JobStoppedMessage>();
        }
    }
}

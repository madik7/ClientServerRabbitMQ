using MediatR;

namespace Client.Application.Handlers.Job
{
    public class StopJobDto : IRequest
    {
        public string Id { get; set; }
    }
}

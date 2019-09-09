using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Application.Handlers.Job
{
    public class CreateJobDto : IRequest<string>
    {
        public string Name { get; set; }
        public int Precision { get; set; }
    }

    public class CreateJobDtoValidator : AbstractValidator<CreateJobDto>
    {
        public CreateJobDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Precision).GreaterThanOrEqualTo(0);
        }
    }
}



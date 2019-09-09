using Server.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Application.Services
{
    public interface IJobService
    {
        void Complete(Job job);
    }
}

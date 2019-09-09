using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BusClient.Lib.Extensions;
using BusClient.Lib.Handlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Server.Application.Handlers;
using Server.Application.Profiles;
using Server.Application.Services;
using Server.Domain.Messages;

namespace Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(JobProfile));
            services.AddSingleton<IJobManager, JobManager>();
            services.AddSingleton<IPiService, PiService>();
            services.AddSingleton<IJobService, JobService>();
            services.AddScoped<IHandler<JobCreatedMessage>, JobCreatedHandler>();
            services.AddScoped<IHandler<JobStoppedMessage>, JobStoppedHandler>();
            services.AddBusClient(Configuration);

            services.AddHostedService<JobBackgroundService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseHandler<JobCreatedMessage>();
            app.UseHandler<JobStoppedMessage>();
        }
    }
}

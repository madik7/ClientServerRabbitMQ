using BusClient.Lib.Handlers;
using BusClient.Lib.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusClient.Lib.Extensions
{
    public static class BusClientExtensions
    {
        public static IServiceCollection AddBusClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<BusClientOptions>(configuration.GetSection("BusClientOptions"));
            services.AddSingleton<IBusClient, BusClient>();

            return services;
        }

        public static IApplicationBuilder UseHandler<TMessage>(this IApplicationBuilder app)
        {
            var client = app.ApplicationServices.GetService<IBusClient>();
            client.Subscribe<TMessage>();
            return app;
        }
    }
}

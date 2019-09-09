using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BusClient.Lib.Handlers;
using BusClient.Lib.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace BusClient.Lib
{
    public class BusClient : IBusClient
    {
        private readonly ConnectionFactory _connectionFactory = new ConnectionFactory();
        private IConnection _connection;

        private readonly BusClientOptions _options;
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<BusClient> _logger;

        public BusClient(IOptions<BusClientOptions> options,IServiceProvider serviceProvider, ILogger<BusClient> logger)
        {
            _options = options.Value;
            _serviceProvider = serviceProvider;
            _logger = logger;
            CreateConnection();
        }


        private void CreateConnection()
        {
            _connectionFactory.UserName = _options.User;
            _connectionFactory.Password = _options.Password;
            _connectionFactory.HostName = _options.Host;
            _connectionFactory.Port = _options.Port;
            _connectionFactory.VirtualHost = _options.VirtualHost;
            _connection = _connectionFactory.CreateConnection();
        }

        public void Publish<TMessage>(TMessage message)
        {
            using (var channel = _connection.CreateModel())
            {
                var messageName = typeof(TMessage).Name;
                channel.QueueDeclare(queue: messageName,
                                  durable: false,
                                  exclusive: false,
                                  autoDelete: false,
                                  arguments: null);

                var json = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(json);

                channel.BasicPublish(exchange: "",
                                     routingKey: messageName,
                                     basicProperties: null,
                                     body: body);
                _logger.LogDebug("Message sent");
            }
        }

        public void Subscribe<TMessage>()
        {
            var channel = _connection.CreateModel();
                var messageName = typeof(TMessage).Name;

                channel.QueueDeclare(queue: messageName,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = JsonConvert.DeserializeObject<TMessage>(Encoding.UTF8.GetString(body));
                    
                    using(var scope = _serviceProvider.CreateScope())
                    {
                        var handler = scope.ServiceProvider.GetService<IHandler<TMessage>>();
                        handler.Handle(message);
                    }
                };
                channel.BasicConsume(queue: messageName,
                                     autoAck: true,
                                     consumer: consumer);
            }
        
    }
}

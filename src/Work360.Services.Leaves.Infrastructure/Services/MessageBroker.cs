using System.Text;
using MediatR;
using Newtonsoft.Json;
using RabbitMQ.Client;
using Work360.Services.Leaves.Application.Services;

namespace Work360.Services.Leaves.Infrastructure.Services;

public class MessageBroker : IMessageBroker
{
    private readonly IConnection _connection;
    private readonly IModel _channel;
    
    public MessageBroker()
    {
        var factory = new ConnectionFactory
        {
            HostName = "localhost",
            Port = 5672
        };
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
        _channel.ExchangeDeclare("leaves", type: ExchangeType.Fanout);
    }

    public Task PublishAsync(params INotification[] events) => PublishAsync(events?.AsEnumerable());

    public Task PublishAsync(IEnumerable<INotification> events)
    {
        if (_connection.IsOpen)
        {
            foreach (var @event in events)
            {
                var message = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event, Formatting.Indented));
                _channel.BasicPublish(exchange: "leaves",
                                    routingKey:"",
                                    basicProperties: null,
                                    body: message);
            }

            return Task.CompletedTask;
        }

        return Task.CompletedTask;
    }
}
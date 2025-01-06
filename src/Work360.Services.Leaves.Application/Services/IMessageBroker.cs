using MediatR;

namespace Work360.Services.Leaves.Application.Services;

public interface IMessageBroker
{
    Task PublishAsync(INotification events);
    Task PublishAsync(IEnumerable<INotification> events);
}
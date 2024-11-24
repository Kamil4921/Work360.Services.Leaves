using Work360.Services.Leaves.Core;
using MediatR;

namespace Work360.Services.Leaves.Application.Services;

public interface IEventMapper
{
    INotification Map(IDomainEvent @event);
    IEnumerable<INotification?> MapAll(IEnumerable<IDomainEvent> events);
}
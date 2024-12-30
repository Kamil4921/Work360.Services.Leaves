using MediatR;
using Work360.Services.Leaves.Application.Services;
using Work360.Services.Leaves.Core;
using Work360.Services.Leaves.Core.Events;

namespace Work360.Services.Leaves.Infrastructure.Services;

public class EventMapper : IEventMapper
{
    public INotification? Map(IDomainEvent @event)
    {
        return @event switch
        {
            EmployeeCreated e => new Application.Events.EmployeeCreated(e.Employee.Id),
            LeaveCreated e => new Application.Events.LeaveCreated(e.LeaveApplication.Id, e.EmployeeName, e.LeaveApplication.StartLeave, e.LeaveApplication.LeaveDuration),
            _ => null
        };
    }

    public IEnumerable<INotification?> MapAll(IEnumerable<IDomainEvent> events)
        => events.Select(Map);
}
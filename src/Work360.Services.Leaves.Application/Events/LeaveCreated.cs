using MediatR;

namespace Work360.Services.Leaves.Application.Events;

public class LeaveCreated(Guid leaveId) : INotification
{
    public Guid LeaveId { get; } = leaveId;
}
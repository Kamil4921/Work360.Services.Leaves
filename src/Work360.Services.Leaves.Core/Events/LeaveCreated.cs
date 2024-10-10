using Work360.Services.Leaves.Core.Entities;

namespace Work360.Services.Leaves.Core.Events;

public class LeaveCreated(LeaveApplication leave) : IDomainEvent
{
    public LeaveApplication LeaveApplication { get; } = leave;
}
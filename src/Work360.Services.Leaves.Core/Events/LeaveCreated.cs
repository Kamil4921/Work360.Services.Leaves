using Work360.Services.Leaves.Core.Entities;

namespace Work360.Services.Leaves.Core.Events;

public class LeaveCreated(LeaveApplication leave, Guid employeeId) : IDomainEvent
{
    public LeaveApplication LeaveApplication { get; } = leave;
    public Guid EmployeeId { get; } = employeeId;
}
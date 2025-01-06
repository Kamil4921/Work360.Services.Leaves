using MediatR;

namespace Work360.Services.Leaves.Application.Events;

public class LeaveCreated(Guid leaveId, Guid employeeId, DateTime leaveStart, int leaveDuration) : INotification
{
    public Guid LeaveId { get; } = leaveId;
    public Guid EmployeeId { get; } = employeeId;
    public DateTime LeaveStart { get; } = leaveStart;
    public int LeaveDuration { get; } = leaveDuration;
}
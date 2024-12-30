using MediatR;

namespace Work360.Services.Leaves.Application.Events;

public class LeaveCreated(Guid leaveId, string employeeFullName, DateTime leaveStart, int leaveDuration) : INotification
{
    public Guid LeaveId { get; } = leaveId;
    public string EmployeeFullName { get; } = employeeFullName;
    public DateTime LeaveStart { get; } = leaveStart;
    public int LeaveDuration { get; } = leaveDuration;
}
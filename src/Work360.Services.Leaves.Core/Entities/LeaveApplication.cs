using Work360.Services.Leaves.Core.Events;
using Work360.Services.Leaves.Core.Exceptions;

namespace Work360.Services.Leaves.Core.Entities;

public class LeaveApplication : AggregateRoot
{
    public DateTime StartLeave { get; set; }
    public int LeaveDuration { get; set; }
    public Guid EmployeeId { get; set; }
    public Employee Employee { get; set; }
    public DateTime CreatedAt { get; private set; }

    public LeaveApplication() { }
    public LeaveApplication(Guid employeeId)
    {
        Id = Guid.NewGuid();
        EmployeeId = employeeId;
        CreatedAt = DateTime.UtcNow;
    }

    public static LeaveApplication CreateApplication(Guid employeeId, DateTime startLeave, int leaveDuration)
    {
        var leave = new LeaveApplication(employeeId);
        leave.SetLeave(startLeave, leaveDuration);
        leave.AddEvent(new LeaveCreated(leave, employeeId));

        return leave;
    }

    private void SetLeave(DateTime startDate, int leaveDuration)
    {
        if (leaveDuration > 21)
        {
            throw new LeaveMaximumDaysException(Id);
        }

        StartLeave = startDate;
        LeaveDuration = leaveDuration;
    }
}
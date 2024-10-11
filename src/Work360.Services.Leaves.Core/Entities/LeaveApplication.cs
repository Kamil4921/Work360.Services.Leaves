using System.Runtime.CompilerServices;
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
    public LeaveApplication(Employee employee)
    {
        Id = new Guid();
        EmployeeId = employee.Id;
        Employee = employee;
        CreatedAt = DateTime.Now;
    }

    public LeaveApplication CreateApplication(Employee employee, DateTime startLeave, int leaveDuration)
    {
        var leave = new LeaveApplication(employee);
        leave.SetLeave(startLeave, leaveDuration);
        leave.AddEvent(new LeaveCreated(leave));

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
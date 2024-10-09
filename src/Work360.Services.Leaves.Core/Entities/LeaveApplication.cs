namespace Work360.Services.Leaves.Core.Entities;

public class LeaveApplication : AggregateRoot
{
    public DateTime StartLeave { get; set; }
    public int LeaveDuration { get; set; }
    public Guid EmployeeId { get; set; }
}
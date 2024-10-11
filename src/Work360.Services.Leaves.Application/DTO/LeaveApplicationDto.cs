using Work360.Services.Leaves.Core.Entities;

namespace Work360.Services.Leaves.Application.DTO;

public class LeaveApplicationDto(LeaveApplication leaveApplication)
{
    public Guid Id { get; set; } = leaveApplication.Id;
    public DateTime StartLeave { get; set; } = leaveApplication.StartLeave;
    public int LeaveDuration { get; set; } = leaveApplication.LeaveDuration;
    public Guid EmployeeId { get; set; } = leaveApplication.EmployeeId;
    //public EmployeeDto Employee { get; set; }
    public DateTime CreatedAt { get; private set; } = leaveApplication.CreatedAt;
}
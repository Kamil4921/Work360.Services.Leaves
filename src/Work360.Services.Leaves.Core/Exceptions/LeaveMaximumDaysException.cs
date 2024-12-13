namespace Work360.Services.Leaves.Core.Exceptions;

public class LeaveMaximumDaysException(Guid leaveId)
    : DomainException($"Leave application with id {leaveId} exceeded maximum leave days.")
{
    public override string Code => "maximum_number_of_vacation_days_exceeded";
    public Guid LeaveId { get; } = leaveId;
}
using MediatR;

namespace Work360.Services.Leaves.Application.Commands;

[Contract]
public class CreateApplication(Guid employeeId, DateTime startLeave, int leaveDuration) : IRequest<Guid>
{
    public Guid EmployeeId { get; } = employeeId;
    public DateTime StartLeave { get; } = startLeave;
    public int LeaveDuration { get; } = leaveDuration;
}
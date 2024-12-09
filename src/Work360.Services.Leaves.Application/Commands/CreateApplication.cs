using MediatR;
using Work360.Services.Leaves.Core.Entities;

namespace Work360.Services.Leaves.Application.Commands;

[Contract]
public class CreateApplication(Employee employee, DateTime startLeave, int leaveDuration) : IRequest<Guid>
{
    public Employee Employee { get; } = employee;
    public DateTime StartLeave { get; } = startLeave;
    public int LeaveDuration { get; } = leaveDuration;
}
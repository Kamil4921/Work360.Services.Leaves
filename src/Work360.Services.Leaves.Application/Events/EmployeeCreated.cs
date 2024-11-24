using MediatR;

namespace Work360.Services.Leaves.Application.Events;

public class EmployeeCreated(Guid employeeId) : INotification
{
    public Guid EmployeeId { get; } = employeeId;
}
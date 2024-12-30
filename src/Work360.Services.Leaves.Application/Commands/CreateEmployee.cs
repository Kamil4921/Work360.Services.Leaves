using MediatR;

namespace Work360.Services.Leaves.Application.Commands;

[Contract]
public class CreateEmployee(Guid employeeId, string employeeFullName) : IRequest<Guid>
{
    public Guid EmployeeId { get; } = employeeId;
    public string EmployeeFullName { get; } = employeeFullName;
}
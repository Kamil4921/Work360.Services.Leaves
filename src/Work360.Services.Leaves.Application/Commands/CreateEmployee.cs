using MediatR;

namespace Work360.Services.Leaves.Application.Commands;

[Contract]
public class CreateEmployee(Guid employeeId) : IRequest<Guid>
{
    public Guid employeeId { get; } = employeeId;
}
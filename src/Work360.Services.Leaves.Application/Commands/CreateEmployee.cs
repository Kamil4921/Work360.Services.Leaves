using MediatR;

namespace Work360.Services.Leaves.Application.Commands;

[Contract]
public class CreateEmployee() : IRequest<Guid>
{
}
using MediatR;
using Work360.Services.Leaves.Application.DTO;

namespace Work360.Services.Leaves.Application.Queries;

public class GetLeaves : IRequest<IEnumerable<LeaveApplicationDto>>
{
}
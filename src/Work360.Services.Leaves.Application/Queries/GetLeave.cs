using MediatR;
using Work360.Services.Leaves.Application.DTO;

namespace Work360.Services.Leaves.Application.Queries;

public class GetLeave(Guid leaveId) : IRequest<LeaveApplicationDto>
{
    public Guid LeaveId { get; } = leaveId;
}
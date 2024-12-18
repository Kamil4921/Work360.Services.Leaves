using MediatR;
using Work360.Services.Leaves.Application.DTO;
using Work360.Services.Leaves.Core.Repositories;

namespace Work360.Services.Leaves.Application.Queries.Handlers;

public class GetLeavesHandler(ILeaveRepository leaveRepository) : IRequestHandler<GetLeaves, IEnumerable<LeaveApplicationDto>>
{
    public async Task<IEnumerable<LeaveApplicationDto>> Handle(GetLeaves request, CancellationToken cancellationToken)
    {
        var leaves = await leaveRepository.GetAllAsync();

        var leavesDto = leaves.Select(leave => new LeaveApplicationDto(leave)).ToList();

        return leavesDto;
    }
}
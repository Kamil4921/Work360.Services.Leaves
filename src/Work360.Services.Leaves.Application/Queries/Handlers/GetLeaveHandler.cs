using MediatR;
using Work360.Services.Leaves.Application.DTO;
using Work360.Services.Leaves.Application.Exceptions;
using Work360.Services.Leaves.Core.Repositories;

namespace Work360.Services.Leaves.Application.Queries.Handlers;

public class GetLeaveHandler(ILeaveRepository leaveRepository) : IRequestHandler<GetLeave, LeaveApplicationDto>
{
    private readonly ILeaveRepository _leaveRepository = leaveRepository;
    
    public async Task<LeaveApplicationDto> Handle(GetLeave request, CancellationToken cancellationToken)
    {
        var leave = await _leaveRepository.GetAsync(request.LeaveId);

        if (leave is null)
        {
            throw new LeaveNotFoundException(request.LeaveId);
        }

        var leaveDto = new LeaveApplicationDto(leave);
        
        return leaveDto;
    }
}
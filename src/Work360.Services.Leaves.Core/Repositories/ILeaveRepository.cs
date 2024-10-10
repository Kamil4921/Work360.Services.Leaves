using Work360.Services.Leaves.Core.Entities;

namespace Work360.Services.Leaves.Core.Repositories;

public interface ILeaveRepository
{
    Task<LeaveApplication> GetAsync(Guid id);
    Task<IEnumerable<LeaveApplication>> GetAllAsync();
    Task AddAsync(LeaveApplication order);
    Task UpdateAsync(LeaveApplication order);
    Task DeleteAsync(Guid id);
}
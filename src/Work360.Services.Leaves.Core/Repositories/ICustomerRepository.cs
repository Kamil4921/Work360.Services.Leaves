using Work360.Services.Leaves.Core.Entities;

namespace Work360.Services.Leaves.Core.Repositories;

public interface ICustomerRepository
{
    Task<bool> ExistAsync(Guid id);
    Task AddAsync(Employee employee);
}
using Microsoft.EntityFrameworkCore;
using Work360.Services.Leaves.Core.Entities;
using Work360.Services.Leaves.Core.Repositories;

namespace Work360.Services.Leaves.Infrastructure.Postgres;

public class EmployeeRepository(AppDbContext context) : ICustomerRepository
{
    public async Task<bool> ExistAsync(Guid id)
    {
        return await context.Employees.AsQueryable().AsNoTracking().AnyAsync(e => e.Id == id);
    }

    public async Task AddAsync(Employee employee)
    {
        await context.Employees.AddAsync(employee);
        await context.SaveChangesAsync();
    }
}
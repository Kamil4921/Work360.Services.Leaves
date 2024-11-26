using Microsoft.EntityFrameworkCore;
using Work360.Services.Leaves.Core.Entities;
using Work360.Services.Leaves.Core.Repositories;

namespace Work360.Services.Leaves.Infrastructure.Postgres;

public class EmployeeRepository(AppDbContext context) : ICustomerRepository
{
    private readonly AppDbContext _context = context;
    public async Task<bool> ExistAsync(Guid id)
    {
        return await _context.Employees.AsQueryable().AsNoTracking().AnyAsync(e => e.Id == id);
    }

    public async Task AddAsync(Employee employee)
    {
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
    }
}
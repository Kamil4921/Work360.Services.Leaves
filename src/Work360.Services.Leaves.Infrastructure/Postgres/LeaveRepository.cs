using Microsoft.EntityFrameworkCore;
using Work360.Services.Leaves.Core.Entities;
using Work360.Services.Leaves.Core.Repositories;

namespace Work360.Services.Leaves.Infrastructure.Postgres;

public class LeaveRepository(AppDbContext context) : ILeaveRepository
{
    private readonly AppDbContext _context = context;

    public async Task<LeaveApplication?> GetAsync(Guid id)
    {
        return await _context.Leaves.AsQueryable().AsNoTracking().FirstOrDefaultAsync(l => l.Id == id);
    }

    public async Task<IEnumerable<LeaveApplication>> GetAllAsync()
    {
        return await _context.Leaves.AsNoTracking().ToListAsync();
    }

    public async Task AddAsync(LeaveApplication order)
    {
        await _context.Leaves.AddAsync(order);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(LeaveApplication order)
    {
        order.Version++;
        await _context.Set<LeaveApplication>()
            .Where(o => o.Id == order.Id)
            .ExecuteUpdateAsync(o => o
                .SetProperty(p => p.StartLeave, order.StartLeave)
                .SetProperty(p => p.LeaveDuration, order.LeaveDuration)
                .SetProperty(p => p.EmployeeId, order.EmployeeId)
                .SetProperty(p => p.Employee, order.Employee)
                .SetProperty(p => p.Events, order.Events)
                .SetProperty(p => p.Version, order.Version));
    }

    public async Task DeleteAsync(Guid id)
    {
        var leaveToDelete = await _context.Leaves.FirstOrDefaultAsync(l => l.Id == id);
        if (leaveToDelete is not null)
        {
            _context.Leaves.Remove(leaveToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
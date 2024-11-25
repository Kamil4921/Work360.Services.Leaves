using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Work360.Services.Leaves.Core.Entities;

namespace Work360.Services.Leaves.Infrastructure.Postgres;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<LeaveApplication> Leaves { get; set; }
}

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=postgres;User ID=postgres;Password=password;Database=postgres");

        return new AppDbContext(optionsBuilder.Options);
    }
}
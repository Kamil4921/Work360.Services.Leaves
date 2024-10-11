using Work360.Services.Leaves.Core.Entities;

namespace Work360.Services.Leaves.Core.Events;

public class EmployeeCreated(Employee employee) : IDomainEvent
{
    public Employee Employee { get; } = employee;
}
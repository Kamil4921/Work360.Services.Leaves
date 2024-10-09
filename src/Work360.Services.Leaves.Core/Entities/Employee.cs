namespace Work360.Services.Leaves.Core.Entities;

public class Employee(Guid id)
{
    public Guid EmployeeId { get; private set; } = id;
}
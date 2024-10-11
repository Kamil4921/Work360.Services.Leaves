using Work360.Services.Leaves.Core.Entities;

namespace Work360.Services.Leaves.Application.DTO;

public class EmployeeDto(Employee employee)
{
    public Guid Id { get; set; } = employee.Id;
}
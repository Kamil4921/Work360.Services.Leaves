using Work360.Services.Leaves.Core.Entities;

namespace Work360.Services.Leaves.Application.DTO;

public class EmployeeDto { 
    public Guid EmployeeId { get; set; }
    public string? EmployeeFullName { get; set; }
    public EmployeeDto() { } 
    public EmployeeDto(Guid employeeId, string employeeFullName)
    {
        EmployeeId = employeeId;
        EmployeeFullName = employeeFullName;
    } 
}
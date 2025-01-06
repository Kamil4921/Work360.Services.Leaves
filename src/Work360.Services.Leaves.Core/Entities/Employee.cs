using Work360.Services.Leaves.Core.Events;

namespace Work360.Services.Leaves.Core.Entities;

public class Employee : AggregateRoot
{
    public ICollection<LeaveApplication> Leaves { get; set; } = new List<LeaveApplication>();
    public string FullName { get; set; }
    
    public Employee(Guid id, string fullName)
    {
        Id = id;
        FullName = fullName;
    }
    
    public static Employee CreateEmployee(Guid id, string fullName)
    {
        var employee = new Employee(id, fullName);
        employee.AddEvent(new EmployeeCreated(employee));

        return employee;
    }
}
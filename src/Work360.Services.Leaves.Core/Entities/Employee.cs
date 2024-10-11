using Work360.Services.Leaves.Core.Events;

namespace Work360.Services.Leaves.Core.Entities;

public class Employee : AggregateRoot
{
    public Employee()
    {
        Id = new Guid();
    }
    
    public Employee CreateEmployee()
    {
        var employee = new Employee();
        employee.AddEvent(new EmployeeCreated(employee));

        return employee;
    }
}
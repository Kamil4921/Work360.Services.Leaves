namespace Work360.Services.Leaves.Application.Exceptions;

public class EmployeeNotFoundException(Guid employeeId) : ApplicationException($"Can't find an employee with id: {employeeId}.")
{
    public override string Code => "employee_not_found";
}
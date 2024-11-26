using MediatR;
using Work360.Services.Leaves.Application.Exceptions;
using Work360.Services.Leaves.Application.Services;
using Work360.Services.Leaves.Core.Entities;
using Work360.Services.Leaves.Core.Repositories;

namespace Work360.Services.Leaves.Application.Commands.Handlers;

public class CreateEmployeeHandler(ICustomerRepository employeeRepository,
    IEventMapper eventMapper, IMessageBroker messageBroker) : IRequestHandler<CreateEmployee, Guid>
{
    private readonly ICustomerRepository _employeeRepository = employeeRepository;
    private readonly IEventMapper _eventMapper = eventMapper;
    private readonly IMessageBroker _messageBroker = messageBroker;

    public async Task<Guid> Handle(CreateEmployee request, CancellationToken cancellationToken)
    {
        if (!(await _employeeRepository.ExistAsync(request.employeeId)))
        {
            throw new EmployeeNotFoundException(request.employeeId);
        }

        var employee = Employee.CreateEmployee();
        var adding = _employeeRepository.AddAsync(employee);
        var events = _eventMapper.MapAll(employee.Events);
        var publishing = _messageBroker.PublishAsync(events);

        await Task.WhenAll(adding, publishing);

        return employee.Id;
    }
}
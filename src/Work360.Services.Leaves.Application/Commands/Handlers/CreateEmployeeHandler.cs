using MediatR;
using Work360.Services.Leaves.Application.Exceptions;
using Work360.Services.Leaves.Application.Services;
using Work360.Services.Leaves.Core.Entities;
using Work360.Services.Leaves.Core.Repositories;

namespace Work360.Services.Leaves.Application.Commands.Handlers;

public class CreateEmployeeHandler(ICustomerRepository customerRepository,
    IEventMapper eventMapper, IMessageBroker messageBroker) : IRequestHandler<CreateEmployee, Guid>
{
    public async Task<Guid> Handle(CreateEmployee request, CancellationToken cancellationToken)
    {
        if (!await customerRepository.ExistAsync(request.EmployeeId))
        {
            throw new EmployeeNotFoundException(request.EmployeeId);
        }

        var employee = Employee.CreateEmployee(request.EmployeeId, request.EmployeeFullName);
        var adding = customerRepository.AddAsync(employee);
        var events = eventMapper.MapAll(employee.Events);
        var publishing = messageBroker.PublishAsync(events);

        await Task.WhenAll(adding, publishing);

        return employee.Id;
    }
}
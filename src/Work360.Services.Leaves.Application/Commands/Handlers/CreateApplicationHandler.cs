using MediatR;
using Work360.Services.Leaves.Application.Exceptions;
using Work360.Services.Leaves.Application.Services;
using Work360.Services.Leaves.Core.Entities;
using Work360.Services.Leaves.Core.Repositories;

namespace Work360.Services.Leaves.Application.Commands.Handlers;

public class CreateApplicationHandler(ILeaveRepository leaveRepository, ICustomerRepository customerRepository,
    IEventMapper eventMapper, IMessageBroker messageBroker) : IRequestHandler<CreateApplication, Guid>
{
    public async Task<Guid> Handle(CreateApplication request, CancellationToken cancellationToken)
    {
        if (!await customerRepository.ExistAsync(request.Employee.Id))
        {
            throw new EmployeeNotFoundException(request.Employee.Id);
        }
        var application = LeaveApplication.CreateApplication(request.Employee, request.StartLeave, request.LeaveDuration);
        var adding = leaveRepository.AddAsync(application);
        var events = eventMapper.MapAll(application.Events);
        var publishing = messageBroker.PublishAsync(events);

        await Task.WhenAll(adding, publishing);

        return application.Id;
    }
}
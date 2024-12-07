using System.Text.Json;
using Azure.Messaging.ServiceBus;
using MediatR;
using Work360.Services.Leaves.Application.Commands;
using Work360.Services.Leaves.Application.DTO;

namespace Work360.Services.Leaves.Infrastructure.Services;

public class ServiceBusMessageReceiver (ISender mediator)
{
    private const string connectionString = "Endpoint=sb://localhost:5672/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=RootManageSharedAccessKeyValue;UseDevelopmentEmulator=true;";
    private const string topicName = "employee-topic";
    private const string subscriptionName = "subscription.3";
    private readonly ISender _mediator = mediator;
    public ServiceBusProcessor _processor;

    public async Task StartAsync()
    {
        var client = new ServiceBusClient(connectionString);
        _processor = client.CreateProcessor(topicName, subscriptionName, new ServiceBusProcessorOptions());

        _processor.ProcessMessageAsync += MessageHandler;
        _processor.ProcessErrorAsync += ErrorHandler;
        Console.WriteLine("starting service bus");
        await _processor.StartProcessingAsync();
    }

    private async Task MessageHandler(ProcessMessageEventArgs args)
    {
        var employee = JsonSerializer.Deserialize<EmployeeDto>(args.Message.Body) ?? throw new ArgumentNullException();
        await _mediator.Send(new CreateEmployee(employee.Id));
    }

    private Task ErrorHandler(ProcessErrorEventArgs args)
    {
        Console.WriteLine("error occured in the topic");
        // dodac handlowanie errorow
        return Task.CompletedTask;
    }
}
using Azure.Messaging.ServiceBus;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Work360.Services.Leaves.Application.Commands;
using Work360.Services.Leaves.Application.DTO;

namespace Work360.Services.Leaves.Infrastructure.Services;

public class ServiceBusMessageReceiver (ISender mediator, ILogger<ServiceBusMessageReceiver> logger)
{
    private const string ConnectionString = "Endpoint=sb://localhost:5672/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=RootManageSharedAccessKeyValue;UseDevelopmentEmulator=true;";
    private const string TopicName = "employee-topic";
    private const string SubscriptionName = "subscription.3";

    public async Task StartAsync()
    {
        var client = new ServiceBusClient(ConnectionString);
        var processor = client.CreateProcessor(TopicName, SubscriptionName, new ServiceBusProcessorOptions());

        processor.ProcessMessageAsync += MessageHandler;
        processor.ProcessErrorAsync += ErrorHandler;
        logger.LogInformation("Starting service bus");
        await processor.StartProcessingAsync();
    }

    private async Task MessageHandler(ProcessMessageEventArgs args)
    {
        var employees = JsonConvert.DeserializeObject<List<EmployeeDto>>(args.Message.Body.ToString())?? throw new ArgumentNullException();
        var employee = employees.First();
        await mediator.Send(new CreateEmployee(employee.EmployeeId, employee.EmployeeFullName));
    }

    private Task ErrorHandler(ProcessErrorEventArgs args)
    {
        logger.LogError("Error occured in the topic");
        //TODO:Add monitoring
        return Task.CompletedTask;
    }
}
using Azure.Messaging.ServiceBus;

namespace Work360.Services.Leaves.Infrastructure.Services;

public class ServiceBusMessageReceiver
{
    private const string connectionString = "Endpoint=sb://localhost:5672/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=RootManageSharedAccessKeyValue;UseDevelopmentEmulator=true;";
    private const string topicName = "employee-topic";
    private const string subscriptionName = "subscription.3";
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

    private Task MessageHandler(ProcessMessageEventArgs args)
    {
        var body = args.Message.Body.ToString();
        Console.WriteLine(body);
        
        return Task.CompletedTask;
    }

    private Task ErrorHandler(ProcessErrorEventArgs args)
    {
        Console.WriteLine("error ocured");
        // dodac handlowanie errorow
        return Task.CompletedTask;
    }
}
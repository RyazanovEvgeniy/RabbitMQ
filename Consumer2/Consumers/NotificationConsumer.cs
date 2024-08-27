using MassTransit;

using Shared;
using System.Text.Json;

namespace Consumer2.Consumers;

public class NotificationTransactionConsumer : IConsumer<INotificationTransaction>
{
    public async Task Consume(ConsumeContext<INotificationTransaction> context)
    {
        var serializedMessage = JsonSerializer.Serialize(context.Message, new JsonSerializerOptions { });

        Console.WriteLine($"NotificationCreated event consumed. Message: {serializedMessage}");
    }
}
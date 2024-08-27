using Shared;

namespace Webapi.Models;

public record NotificationTransactionDto : INotificationTransaction
{
    public DateTime NotificationDate { get; init; }
    public string? NotificationMessage { get; init; }
    public NotificationType NotificationType { get; init; }
}
namespace Shared;

public enum NotificationType
{
    Email,
    Push,
    Sms
}

public interface INotificationTransaction
{
    DateTime NotificationDate { get; }
    string? NotificationMessage { get; }
    NotificationType NotificationType { get; }
}
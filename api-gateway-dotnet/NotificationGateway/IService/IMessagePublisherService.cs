namespace NotificationGateway.IService
{
    public interface IMessagePublisherService
    {
        Task PublishNotificationAsync(NotificationType type, string recipient, string? subject, string message, Guid notificationId, string requestId);
    }
}

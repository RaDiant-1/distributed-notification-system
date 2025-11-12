using NotificationGateway.Model.DTOs;

namespace NotificationGateway.IService
{
    public interface INotificationService
    {
        Task<BaseResponse<NotificationResponse>> SendEmailNotificationAsync(SendEmailRequest request);
        Task<BaseResponse<NotificationResponse>> SendPushNotificationAsync(SendPushRequest request);
    }
}

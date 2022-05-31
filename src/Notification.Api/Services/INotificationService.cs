namespace Notification.Api.Services;

using Microsoft.Azure.NotificationHubs;

using Notification.Api.Models;

public interface INotificationService
{
    Task<IEnumerable<RegistrationDescription>> GetAll();
    Task<bool> CreateOrUpdateInstallationAsync(DeviceInstallation deviceInstallation, CancellationToken token);
    Task<bool> DeleteInstallationByIdAsync(string installationId, CancellationToken token);
    Task<bool> RequestNotificationAsync(NotificationRequest notificationRequest, CancellationToken token);

}

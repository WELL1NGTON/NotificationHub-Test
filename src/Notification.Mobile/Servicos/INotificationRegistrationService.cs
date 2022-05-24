using System.Threading.Tasks;

namespace Notification.Mobile.Servicos
{
    public interface INotificationRegistrationService
    {
        Task DeregisterDeviceAsync();
        Task RegisterDeviceAsync(params string[] tags);
        Task RefreshRegistrationAsync();
    }
}

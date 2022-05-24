using System;

using Notification.Mobile.Models;

namespace Notification.Mobile.Servicos
{
    public interface IPushDemoNotificationActionService : INotificationActionService
    {
        event EventHandler<PushDemoAction> ActionTriggered;
    }
}

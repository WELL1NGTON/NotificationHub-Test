using Notification.Mobile.Models;
using Notification.Mobile.Servicos;

using Xamarin.Essentials;
using Xamarin.Forms;

namespace Notification.Mobile
{
    public partial class App : Application
    {
        void NotificationActionTriggered(object sender, PushDemoAction e)
            => ShowActionAlert(e);

        void ShowActionAlert(PushDemoAction action)
            => MainThread.BeginInvokeOnMainThread(()
                => MainPage?.DisplayAlert("PushDemo", $"{action} action received", "OK")
                    .ContinueWith((task) => { if (task.IsFaulted) throw task.Exception; }));

        public App()
        {
            InitializeComponent();

            ServiceContainer.Resolve<IPushDemoNotificationActionService>()
                .ActionTriggered += NotificationActionTriggered;

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

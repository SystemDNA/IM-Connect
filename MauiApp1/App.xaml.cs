using MauiApp1.Services;

namespace MauiApp1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new MainPage()) { Title = "MauiApp1" };
        }
        protected override void OnSleep()
        {
            // Clear auth if app is killed (simulate app termination)
            SessionManager.ClearAuthentication();
        }
    }
}

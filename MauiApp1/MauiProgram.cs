using MauiApp1.Services;
using Microsoft.Extensions.Logging;

namespace MauiApp1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddSingleton<BiometricAuthService>();
           
            builder.Services.AddSingleton<UserLocationService>();
            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://platformfactory.uk:6888/") });

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}

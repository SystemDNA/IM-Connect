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
            builder.Services.AddSingleton<ProductService>();
            builder.Services.AddSingleton<CountriesListService>();
            builder.Services.AddSingleton<CountriesDataService>();
            builder.Services.AddScoped<EventsDataService>();
            builder.Services.AddScoped<TemplateService>(); 
            builder.Services.AddScoped<SelectedCountryService>();
            builder.Services.AddSingleton<NewsService>();
            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://platformfactory.uk:6888/") });
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://oneplatformfactory.com/IM_API/") });
            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://oneplatformfactory.com/Converter/") });

            //builder.Services.AddScoped<ProductService>();
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}

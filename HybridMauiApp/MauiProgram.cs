using HybridMauiApp.Clients;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Shared.Components;

namespace HybridMauiApp
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

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<ToDoListClient>();
            builder.Services.AddSingleton<HttpClient>();
            builder.Services.AddMyRclServices();
            return builder.Build();
        }
    }
}

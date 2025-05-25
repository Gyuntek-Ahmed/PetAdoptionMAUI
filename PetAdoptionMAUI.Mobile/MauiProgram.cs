using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace PetAdoptionMAUI.Mobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            // Register app dependencies
            RegisterAppDependencies(builder.Services);
            return builder.Build();
        }

        static void RegisterAppDependencies(IServiceCollection services)
        {
            // Register your services and view models here
            services
                .AddTransient<LoginRegisterViewModel>()
                .AddTransient<LoginRegisterPage>();
        }
    }
}

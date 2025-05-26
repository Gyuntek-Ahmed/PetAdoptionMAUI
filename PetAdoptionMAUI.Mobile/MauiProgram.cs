using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using PetAdoptionMAUI.Shared;
using Refit;

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
            // Configure Refit clients
            ConfigureRefit(builder.Services);

            return builder.Build();
        }

        static void RegisterAppDependencies(IServiceCollection services)
        {
            // Register your services and view models here
            services.AddSingleton<CommonService>();

            services.AddTransient<AuthService>();
            services
                .AddTransient<LoginRegisterViewModel>()
                .AddTransient<LoginRegisterPage>();

            services
                .AddSingleton<HomeViewModel>()
                .AddSingleton<HomePage>();

            services
                .AddTransientWithShellRoute<DetailsPage, DetailsViewModel>(nameof(DetailsPage));
        }

        static void ConfigureRefit(IServiceCollection services)
        {
            // Configure Refit clients here if needed
            services
                .AddRefitClient<IAuthApi>()
                .ConfigureHttpClient(SetHttpClient);

            services
                .AddRefitClient<IPetsApi>()
                .ConfigureHttpClient(SetHttpClient);

            services
                .AddRefitClient<IUserApi>(sp =>
                {
                    var commonService = sp.GetRequiredService<CommonService>();
                    return new RefitSettings()
                    {
                        AuthorizationHeaderValueGetter = (_, __) => Task.FromResult(commonService.Token ?? string.Empty)
                    };
                })
                .ConfigureHttpClient(SetHttpClient);

            static void SetHttpClient(HttpClient httpClient)
                => httpClient.BaseAddress = new Uri(AppConstants.BaseApiUrl);
        }
    }
}
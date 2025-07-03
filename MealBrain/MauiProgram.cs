using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using MealBrain.Data.Repositories;
using MealBrain.Utilities.Helpers;

namespace MealBrain
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

			// Dependency Injection
			// Scopes: Singleton (One and only one instance), Scoped (the scope of where it is injected), Transient (no specific lifetime but usually follow that of the host)
			builder.RegisterServices()
                .RegisterRepositories()
				.RegisterViewModels()
				.RegisterViews();

			return builder.Build();
        }

        /// <summary>
        /// Extension member for registering the view models in the DI container.
        /// This only needs the viewmodel class passed into the types.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
        {
            // Example: builder.Services.AddTransient<ViewModelClassName>(); 
            return builder;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
        {
            // Example: builder.Services.AddScoped<
            return builder;
        }

        /// <summary>
        /// Extension member for registering the services in the DI container.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
        {
            // Example: builder.Services.AddScoped<IServiceInterfaceName, ServiceClassToInject>();
            return builder;
        }

        /// <summary>
        /// Extension member for registering the repository classes in the DI container.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static MauiAppBuilder RegisterRepositories(this MauiAppBuilder builder)
        {
			string dbPath = FileAccessHelper.GetLocalFilePath("mealbrain.db3");
			builder.Services.AddSingleton<IMeasurementRepository, MeasurementRepository>(
				s => ActivatorUtilities.CreateInstance<MeasurementRepository>(s, dbPath));
			return builder;
        }
    }
}

using CodeIt.Services;
using CodeIt.ViewModels;
using CodeIt.Views;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace CodeIt
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
            AddCourseServices(builder.Services);
            return builder.Build();
        }
        private static IServiceCollection AddCourseServices(IServiceCollection services)
        {
            services.AddSingleton<CourseService>();

            services.AddSingleton<HomePage>();
            services.AddSingletonWithShellRoute<HomePage,HomeViewModel>(nameof(HomePage));

            services.AddTransientWithShellRoute<AllCoursesPage, AllCourseViewModel>(nameof(AllCoursesPage));

            services.AddTransientWithShellRoute<DetailPage, DetailsViewModel>(nameof(DetailPage));

            services.AddSingleton<CartViewModel>();
            services.AddTransient<CartPage>();
            return services;
        }
    }

}
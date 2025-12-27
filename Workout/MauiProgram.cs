using Microsoft.Extensions.Logging;
using Workout.ViewModels;
using CommunityToolkit.Maui;
using Workout.Data;
using Workout.Views;

namespace Workout;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>().ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        }).UseMauiCommunityToolkit();
        builder.Services.AddSingleton<WorkoutDatabase>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddTransient<ExerciseViewModel>();
        builder.Services.AddTransient<ExercisePage>();
        builder.Services.AddTransient<WorkoutViewModel>();
        builder.Services.AddTransient<WorkoutPage>();
        builder.Services.AddTransient<ExerciseDetailPage>();
        builder.Services.AddTransient<ExerciseDetailViewModel>();

        

        
#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}
using Workout.Views;

namespace Workout;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        
        Routing.RegisterRoute(nameof(WorkoutPage), typeof(WorkoutPage));
        Routing.RegisterRoute(nameof(ExercisePage), typeof(ExercisePage));
        Routing.RegisterRoute(nameof(ExerciseDetailPage), typeof(ExerciseDetailPage));
    }
}
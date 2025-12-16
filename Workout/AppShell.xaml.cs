using Workout.Views;

namespace Workout;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        
        Routing.RegisterRoute(nameof(WorkoutPage), typeof(WorkoutPage));
    }
}
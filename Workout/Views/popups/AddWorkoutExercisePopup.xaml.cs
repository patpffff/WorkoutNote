using CommunityToolkit.Maui.Views;
using Workout.ViewModels;

namespace Workout.Views.popups;

public partial class AddWorkoutExercisePopup : Popup<string>
{
    public AddWorkoutExercisePopup(WorkoutViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }


    private async void OnOkClicked(object? sender, EventArgs e)
    {
        await CloseAsync();
    }

    private async void OnCancelClicked(object? sender, EventArgs e)
    {
        await CloseAsync();
    }

    private async void OnNewExerciseClicked(object? sender, EventArgs e)
    {
        await CloseAsync();
        await Shell.Current.GoToAsync(nameof(ExercisePage));
    }
}
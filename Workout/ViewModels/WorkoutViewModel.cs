using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Workout.Models;

namespace Workout.ViewModels;
[QueryProperty(nameof(Workout), "Workout")]

public partial class WorkoutViewModel : ObservableObject
{
    public event Func<Task>? AddExerciseRequested;
    [ObservableProperty]
    private WorkoutPlan workout;
    
    [RelayCommand]
    Task Back() => Shell.Current.GoToAsync("..");

    [RelayCommand]
    async Task AddWithPopup()
    {
        if (AddExerciseRequested != null)
            await AddExerciseRequested.Invoke();
    }


}
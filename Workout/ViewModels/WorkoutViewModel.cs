using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Workout.Models;

namespace Workout.ViewModels;
[QueryProperty(nameof(Workout), "Workout")]

public partial class WorkoutViewModel : ObservableObject
{
    [ObservableProperty]
    private WorkoutPlan workout;
    
    [RelayCommand]
    Task Back() => Shell.Current.GoToAsync("..");
}
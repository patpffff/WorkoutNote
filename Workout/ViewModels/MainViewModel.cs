using System.Collections.ObjectModel;
using System.Collections.Specialized;
using CommunityToolkit.Maui.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Workout.Data;
using Workout.Models;
using Workout.Views;
using PropertyChangingEventHandler = Microsoft.Maui.Controls.PropertyChangingEventHandler;

namespace Workout.ViewModels;

public partial class MainViewModel : ObservableObject
{
    WorkoutDatabase _database;
    public event Func<Task>? AddWorkoutRequested;
    public MainViewModel(WorkoutDatabase database)
    {
        _database = database;
        Workouts = new ObservableCollection<WorkoutPlan>();
    }
    [ObservableProperty] 
    private ObservableCollection<WorkoutPlan> _workouts;

    [ObservableProperty] 
    private WorkoutPlan _workoutPlan;

    [RelayCommand]
    public async Task LoadWorkoutsAsync()
    {
        Workouts.Clear();

        var workouts = await _database.GetWorkoutPlanAsync();
        foreach (var workout in workouts)
            Workouts.Add(workout);
    }

    [RelayCommand]
    async Task AddWithPopup()
    {
        if (AddWorkoutRequested != null)
            await AddWorkoutRequested.Invoke();
    }

    [RelayCommand]
    async Task Delete(WorkoutPlan workout)
    {
        await _database.DeleteWorkoutPlanAsync(workout);
        Workouts.Remove(workout);
    }
    
    [RelayCommand]
    public async Task AddWorkout(string result)
    {
        var newPlan = new WorkoutPlan
        {
            Name = result
        };
        await _database.SaveWorkoutPlanAsync(newPlan);
        Workouts.Add(newPlan);
    }

    [RelayCommand]
    async Task Navigation(WorkoutPlan workout)
    {
        await Shell.Current.GoToAsync(
            nameof(WorkoutPage),
            new Dictionary<string, object>
            {
                ["Workout"] = workout
            });
    }

}
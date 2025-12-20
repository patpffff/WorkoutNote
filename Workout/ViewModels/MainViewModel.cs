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
    async Task AddWithPopup()
    {
        if (AddWorkoutRequested != null)
            await AddWorkoutRequested.Invoke();
    }

    [RelayCommand]

    void Delete(WorkoutPlan workout)
    {
        Workouts.Remove(workout);
    }
    
    [RelayCommand]
    public void AddWorkout(string result)
    {
        var newPlan = new WorkoutPlan
        {
            WorkoutID = Workouts.Count + 1,
            Name = result
        };
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
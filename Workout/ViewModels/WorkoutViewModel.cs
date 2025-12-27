using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Workout.Data;
using Workout.Models;
using Workout.Views;

namespace Workout.ViewModels;
[QueryProperty(nameof(Workout), "Workout")]

public partial class WorkoutViewModel : ObservableObject
{
    public event Func<Task>? AddWorkoutExerciseRequested;
    
    WorkoutDatabase _database;
    
    [ObservableProperty]
    private WorkoutPlan workout;

    [ObservableProperty]
    private ObservableCollection<Exercise> _exercises;
    
    [ObservableProperty] 
    private ObservableCollection<WorkoutPlanExercise> _workoutPlanExercises;
    

    
    public WorkoutViewModel(WorkoutDatabase database)
    {
        _database = database;
        _workoutPlanExercises = new ObservableCollection<WorkoutPlanExercise>();
        Exercises = new ObservableCollection<Exercise>();
    }





    [RelayCommand]
    Task Back() => Shell.Current.GoToAsync("..");

    [RelayCommand]
    async Task AddWithPopup()
    {
        if (AddWorkoutExerciseRequested != null)
            await AddWorkoutExerciseRequested.Invoke();
    }
    
    [RelayCommand]
    public async Task LoadWorkoutPlanExercisesAsync()
    {
        if (Workout == null)
            return;

        _workoutPlanExercises.Clear();

        var result = await _database.GetWorkoutPlanExercise(Workout.WorkoutID);
        foreach (var wpe in result)
            _workoutPlanExercises.Add(wpe);
    }
    
    [RelayCommand]
    public async Task LoadExercisesAsync()
    {
        Exercises.Clear();
        var result = await _database.GetExerciseAsync();
        foreach (var exercise in result)
            Exercises.Add(exercise);
    }
}
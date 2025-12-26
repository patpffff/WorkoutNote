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
    public event Func<Task>? AddExerciseRequested;
    
    WorkoutDatabase _database;
    
    [ObservableProperty]
    private WorkoutPlan workout;


    
    [ObservableProperty] 
    private ObservableCollection<WorkoutPlanExercise> _workoutPlanExercises;
    

    
    public WorkoutViewModel(WorkoutDatabase database)
    {
        _database = database;
        _workoutPlanExercises = new ObservableCollection<WorkoutPlanExercise>();
        Exercises = new ObservableCollection<Exercise>();
    }
    [ObservableProperty]
    private ObservableCollection<Exercise> _exercises;




    [RelayCommand]
    Task Back() => Shell.Current.GoToAsync("..");

    [RelayCommand]
    async Task AddWithPopup()
    {
        if (AddExerciseRequested != null)
            await AddExerciseRequested.Invoke();
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
        var result = await _database.GetExerciseAsync();
        foreach (var exercise in result)
            Exercises.Add(exercise);
    }
}
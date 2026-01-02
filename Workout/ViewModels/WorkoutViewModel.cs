using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Workout.Data;
using Workout.Models;
using Workout.Views;
using Workout.Views.view;

namespace Workout.ViewModels;
[QueryProperty(nameof(Workout), "Workout")]

public partial class WorkoutViewModel : ObservableObject
{
    public event Func<Task>? AddWorkoutExerciseRequested;
    
    WorkoutDatabase _database;
    
    [ObservableProperty]
    private WorkoutPlan _workout;

    [ObservableProperty]
    private ObservableCollection<Exercise> _exercises;
    
    [ObservableProperty] 
    private ObservableCollection<WorkoutPlanExercise> _workoutPlanExercises;

    [ObservableProperty] 
    private ObservableCollection<WorkoutPlanExerciseView> _workoutPlanExerciseViews;


    public WorkoutViewModel(WorkoutDatabase database)
    {
        WorkoutPlanExerciseViews = new ObservableCollection<WorkoutPlanExerciseView>();
        _database = database;
        _workoutPlanExercises = new ObservableCollection<WorkoutPlanExercise>();
        Exercises = new ObservableCollection<Exercise>();
    }

    [RelayCommand]
    public async Task AddExerciseToWorkout(Exercise exercise)
    {
        if (exercise.ExerciseID != null && Workout.WorkoutID != null)
        {
            var entry = new WorkoutPlanExercise
            {
                WorkoutPlanID = Workout.WorkoutID,
                ExerciseID = exercise.ExerciseID,
                OrderIndex = WorkoutPlanExercises.Count
            };
            WorkoutPlanExercises.Add(entry);
            await _database.AddWorkoutPlanExercise(entry);
            await Shell.Current.ClosePopupAsync();
        }
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
    
    [RelayCommand]
    public async Task LoadWorkoutPlanExerciseViewAsync()
    {
        WorkoutPlanExerciseViews.Clear();
        await LoadExercisesAsync();
        await LoadWorkoutPlanExercisesAsync();
        foreach (var wpe in WorkoutPlanExercises)
        {
            WorkoutPlanExerciseViews.Add(new WorkoutPlanExerciseView
            {
                WorkoutPlanExerciseId = wpe.WorkoutPlanExerciseId,
                WorkoutPlanID = wpe.WorkoutPlanID,
                ExerciseID = wpe.ExerciseID,
                ExerciseName = Exercises.Where(e => e.ExerciseID == wpe.ExerciseID).Select(e => e.Name).FirstOrDefault(),
                OrderIndex = wpe.OrderIndex
            });
        }
    }

    [RelayCommand]
    public async Task Navigation(WorkoutPlanExerciseView workoutPlanExerciseView)
    {
        await Shell.Current.GoToAsync(nameof(ExerciseDetailPage), new Dictionary<string, object>
        {
            ["WorkoutPlanExerciseView"]  = workoutPlanExerciseView
        });
    }
}
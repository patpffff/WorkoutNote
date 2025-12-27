using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Workout.Data;
using Workout.Models;
using Workout.Views;

namespace Workout.ViewModels;

public partial class ExerciseViewModel: ObservableObject
{
    public event Func<Task>? AddExerciseRequested;
    WorkoutDatabase _database;
    
    
    [ObservableProperty]
    ObservableCollection<Exercise> exercises;
    
    public ExerciseViewModel(WorkoutDatabase database)
    {
        _database = database;
        Exercises = new ObservableCollection<Exercise>();
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
    public async Task AddExerciseAsync(string exerciseName)
    {
        var newExercise = new Exercise
        {
            Name = exerciseName
        };
        await _database.SaveExerciseAsync(newExercise);
        Exercises.Add(newExercise);
    }
    
    [RelayCommand]
    async Task AddWithPopup()
    {
        if (AddExerciseRequested != null)
            await AddExerciseRequested.Invoke();
    }
    [RelayCommand]
    async Task Delete(Exercise exercise)
    {
        await _database.DeleteExerciseAsync(exercise);
        Exercises.Remove(exercise);
    }
    [RelayCommand]
    async Task Navigation(Exercise exercise)
    {
        await Shell.Current.GoToAsync(
            nameof(ExerciseDetailPage),
            new Dictionary<string, object>
            {
                ["Exercise"] = exercise
            });
    }
}
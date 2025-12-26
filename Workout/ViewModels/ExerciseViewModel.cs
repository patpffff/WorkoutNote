using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Workout.Data;
using Workout.Models;

namespace Workout.ViewModels;

public partial class ExerciseViewModel: ObservableObject
{
    WorkoutDatabase _database;
    
    [ObservableProperty]
    private Exercise exercise;
    
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
        foreach (var entry in result)
            Exercises.Add(entry);
    }
    [RelayCommand]
    public async Task SaveExerciseAsync()
    {
        await _database.SaveExerciseAsync(Exercise);
        await Shell.Current.GoToAsync("..");
    }
}
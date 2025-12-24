using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Workout.Data;
using Workout.Models;

namespace Workout.ViewModels;

public partial class AddExercisePopupViewModel: ObservableObject
{
    WorkoutDatabase _database;
    
    public AddExercisePopupViewModel(WorkoutDatabase database)
    {
        _database = database;
        Exercises = new ObservableCollection<Exercise>();
    }
    [ObservableProperty]
    private ObservableCollection<Exercise> _exercises;
    
    [RelayCommand]
    public async Task LoadExercisesAsync()
    {
        var result = await _database.GetExerciseAsync();
        foreach (var exercise in result)
            Exercises.Add(exercise);
        
        var test = new Exercise {Name = "Test"};
        Exercises.Add(test);
    }
}
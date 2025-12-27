using CommunityToolkit.Mvvm.ComponentModel;
using Workout.Data;
using Workout.Models;

namespace Workout.ViewModels;
[QueryProperty(nameof(Exercise), "Exercise")]

public partial class ExerciseDetailViewModel: ObservableObject
{
    WorkoutDatabase _database;
    
    [ObservableProperty]
    Exercise exercise;

    public ExerciseDetailViewModel(WorkoutDatabase database)
    {
        _database = database;
    }

}
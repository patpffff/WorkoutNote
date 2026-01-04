using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Workout.Data;
using Workout.Models;
using Workout.Views.view;

namespace Workout.ViewModels;
[QueryProperty(nameof(Exercise), "Exercise")]
[QueryProperty(nameof(WorkoutPlanExerciseView), "WorkoutPlanExerciseView")]

public partial class ExerciseDetailViewModel: ObservableObject
{
    WorkoutDatabase _database;
    [ObservableProperty] private int _exerciseIdFromObject;
    [ObservableProperty] private bool _isHistoryExpanded;
    [ObservableProperty] private string _title = string.Empty;
    [ObservableProperty] private Exercise? _exercise;
    [ObservableProperty] private WorkoutPlanExerciseView? _workoutPlanExerciseView;

    [ObservableProperty] 
    private ObservableCollection<SetEntry> _setEntries;
    [ObservableProperty] 
    private ObservableCollection<SetEntry> _setHistory;

    public ExerciseDetailViewModel(WorkoutDatabase database)
    {
        _database = database;
        SetEntries = new ObservableCollection<SetEntry>();
        SetHistory = new ObservableCollection<SetEntry>();
        IsHistoryExpanded = false;
    }
    [RelayCommand]
    public async Task LoadSetEntriesAsync()
    {
        SetEntries.Clear();
        SetEntries.Add(new SetEntry
        {
            ExerciseId = ExerciseIdFromObject,
            setNumber = SetEntries.Count+1,
            repetitions = null,
            weight = null,
            performedAt =  DateTime.Now,
        });
    }
    [RelayCommand]
    public void AddSet()
    {
        SetEntries.Add(new SetEntry
        {
            ExerciseId = ExerciseIdFromObject,
            setNumber = SetEntries.Count+1,
            repetitions = null,
            weight = null,
            performedAt =  DateTime.Now,
        });
    }

    partial void OnWorkoutPlanExerciseViewChanged(WorkoutPlanExerciseView value)
    {
        if (value == null) 
            return;      
        Title = value.ExerciseName;
        ExerciseIdFromObject = value.ExerciseID;
    }
    partial void OnExerciseChanged(Exercise value)
    {
        if (value == null) 
            return;

        Title = value.Name;
        ExerciseIdFromObject = value.ExerciseID;
    }

    [RelayCommand]
    public void RemoveSet()
    {
        if (SetEntries.Any())
        {
            SetEntries.Remove(SetEntries.Last());
        }
    }

    [RelayCommand]
    public async Task SaveSet()
    {
        foreach (var entry in SetEntries)
        {
            if (entry.repetitions > 0 && entry.weight > 0)
            {
                entry.performedAt = DateTime.Now;
                await _database.AddSetEntryAsync(entry);
            }
        }
        SetEntries.Clear();
    }

    [RelayCommand]
    public async Task LoadSetHistory()
    {
        if (!IsHistoryExpanded)
        {
            SetHistory.Clear();
            return;
        }
      
        var result = await _database.GetSetEntry(ExerciseIdFromObject);
        foreach (var setEntry in result)
        {
            SetHistory.Add(setEntry);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Extensions;
using Workout.ViewModels;

namespace Workout.Views;

public partial class WorkoutPage : ContentPage
{
    private readonly AddExercisePopupViewModel _popupViewModel;

    public WorkoutPage(WorkoutViewModel vm, AddExercisePopupViewModel popupViewModel)
    {
        InitializeComponent();
        BindingContext = vm;
        _popupViewModel = popupViewModel;
        vm.AddExerciseRequested += OnAddExerciseRequested;

    }
    
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is WorkoutViewModel vm)
        {
            await vm.LoadWorkoutPlanExercisesAsync();
        }
    }
    
    async Task OnAddExerciseRequested()
    {
        var vm = (WorkoutViewModel)BindingContext;
        
        // ERST Daten laden
        await vm.LoadExercisesAsync();
        
        // DANN Popup mit Daten erstellen
        var popup = new AddExercisePopup(vm);
        
        var popupResult = await this.ShowPopupAsync<string>(popup);
        var result = popupResult.Result;

        if (!string.IsNullOrEmpty(result))
        {
            // Übergabe ans ViewModel
           // var vm = (WorkoutViewModel)BindingContext;
            //vm.AddWorkout(result);
        }
    }
}
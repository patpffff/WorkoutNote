using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Extensions;
using Workout.ViewModels;
using Workout.Views.popups;

namespace Workout.Views;

public partial class WorkoutPage : ContentPage
{
    public WorkoutPage(WorkoutViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        vm.AddWorkoutExerciseRequested += OnAddWorkoutExerciseRequested;

    }
    
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is WorkoutViewModel vm)
        {
            await vm.LoadWorkoutPlanExercisesAsync();
        }
    }
    
    async Task OnAddWorkoutExerciseRequested()
    {
        var vm = (WorkoutViewModel)BindingContext;
        
        // ERST Daten laden
        await vm.LoadExercisesAsync();
        
        // DANN Popup mit Daten erstellen
        var popup = new AddWorkoutExercisePopup(vm);
        
        var popupResult = await this.ShowPopupAsync<string>(popup, new PopupOptions
        {
            CanBeDismissedByTappingOutsideOfPopup = false,
            PageOverlayColor = Colors.Black.WithAlpha(0.75f)
        });
        var result = popupResult.Result;

        if (!string.IsNullOrEmpty(result))
        {
            // Übergabe ans ViewModel
            //vm.AddWorkout(result);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Extensions;
using Workout.Data;
using Workout.Models;
using Workout.ViewModels;
using Workout.Views.popups;

namespace Workout.Views;

public partial class ExercisePage : ContentPage
{
    public ExercisePage(ExerciseViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        vm.AddExerciseRequested += OnAddExerciseRequested;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is ExerciseViewModel vm)
        {
            await vm.LoadExercisesAsync();
        }
    }

    async Task OnAddExerciseRequested()
    {
        var popup = new AddExercisePopup();
        var popupResult = await this.ShowPopupAsync<string>(popup, new PopupOptions
        {
            CanBeDismissedByTappingOutsideOfPopup = false,
            PageOverlayColor = Colors.Black.WithAlpha(0.9f)
        });
        var result = popupResult.Result;
        
        if (!string.IsNullOrEmpty(result))
        {
            // Übergabe ans ViewModel
            var vm = (ExerciseViewModel)BindingContext;
            await vm.AddExerciseAsync(result);
        }
    }
}
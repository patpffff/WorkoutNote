using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Extensions;
using Workout.ViewModels;

namespace Workout.Views;

public partial class WorkoutPage : ContentPage
{
    public WorkoutPage(WorkoutViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
        vm.AddExerciseRequested += OnAddExerciseRequested;

    }
    
    async Task OnAddExerciseRequested()
    {
        var popup = new AddExercisePopup();
        var popupResult = await this.ShowPopupAsync<string>(popup);
        var result = popupResult.Result;

        if (!string.IsNullOrEmpty(result))
        {
            // Übergabe ans ViewModel
            var vm = (WorkoutViewModel)BindingContext;
            //vm.AddWorkout(result);
        }
    }
}
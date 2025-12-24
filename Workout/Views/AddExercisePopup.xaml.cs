using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Views;
using Workout.Data;
using Workout.ViewModels;

namespace Workout.Views;

public partial class AddExercisePopup : Popup<string>
{
    public AddExercisePopup(WorkoutViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }


    private async void OnOkClicked(object? sender, EventArgs e)
    {
        await CloseAsync();
    }

    private async void OnCancelClicked(object? sender, EventArgs e)
    {
        await CloseAsync();
    }
}
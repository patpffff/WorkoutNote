using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Views;
using Workout.Models;

namespace Workout.Views.popups;

public partial class AddExercisePopup : Popup<string>
{
    public AddExercisePopup()
    {
        InitializeComponent();
    }
    public async void OnOkClicked(object? sender, EventArgs e)
    {
        await CloseAsync(ExerciseName.Text);
    }
    
    private async void OnCancelClicked(object? sender, EventArgs e)
    {
        await CloseAsync();
    }
}
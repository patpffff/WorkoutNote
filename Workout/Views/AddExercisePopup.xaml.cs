using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Views;

namespace Workout.Views;

public partial class AddExercisePopup : Popup<string>
{
    public AddExercisePopup()
    {
        InitializeComponent();
    }

    private async void OnOkClicked(object? sender, EventArgs e)
    {
        await CloseAsync(Exercise.Text);
    }

    private async void OnCancelClicked(object? sender, EventArgs e)
    {
        await CloseAsync();
    }
}
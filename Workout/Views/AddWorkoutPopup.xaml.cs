using CommunityToolkit.Maui.Views;


namespace Workout.Views;

public partial class AddWorkoutPopup: Popup<string>
{

    public AddWorkoutPopup()
    {
        InitializeComponent();
    }
    

    private async void OnOkClicked(object? sender, EventArgs e)
    {
        await CloseAsync(Workoutname.Text);
    }

    private async void OnCancelClicked(object? sender, EventArgs e)
    {
        await CloseAsync();
    }
}
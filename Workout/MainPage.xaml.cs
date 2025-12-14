using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Maui.Views;
using Workout.Models;
using Workout.ViewModels;
using Workout.Views;

namespace Workout;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;

        vm.AddWorkoutRequested += OnAddWorkoutRequested;
    }

    async Task OnAddWorkoutRequested()
    {
        var popup = new AddWorkoutPopup();
        var popupResult = await this.ShowPopupAsync<string>(popup);
        var typeName = popupResult.GetType().FullName;  // Ausgabe im Debugger
        var result = popupResult.Result;

        if (!string.IsNullOrEmpty(result))
        {
            // Übergabe ans ViewModel
            var vm = (MainViewModel)BindingContext;
            vm.AddWorkout(result);
        }
    }
}
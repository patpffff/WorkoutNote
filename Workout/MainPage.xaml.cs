using CommunityToolkit.Maui;
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
    
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is MainViewModel vm)
        {
            await vm.LoadWorkoutsAsync();
        }
    }

    async Task OnAddWorkoutRequested()
    {
        var popup = new AddWorkoutPopup();
        var popupResult = await this.ShowPopupAsync<string>(popup, new PopupOptions
        {
            CanBeDismissedByTappingOutsideOfPopup = false,
        });
        var result = popupResult.Result;

        if (!string.IsNullOrEmpty(result))
        {
            // Übergabe ans ViewModel
            var vm = (MainViewModel)BindingContext;
            vm.AddWorkout(result);
        }
    }
}
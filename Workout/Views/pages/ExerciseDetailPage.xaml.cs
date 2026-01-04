using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Core;
using Workout.ViewModels;

namespace Workout.Views;

public partial class ExerciseDetailPage : ContentPage
{
    public ExerciseDetailPage(ExerciseDetailViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing(); 
        if (BindingContext is ExerciseDetailViewModel vm)
        {
            await vm.LoadSetEntriesAsync();
        }
    }
}
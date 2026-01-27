using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Core.Platform;
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
            await vm.LoadExercise();
        }
    }

    private async void Editor_Unfocused(object? sender, FocusEventArgs e)
    {
        if (BindingContext is ExerciseDetailViewModel vm)
        {
            await vm.SaveExerciseComment();
        }
    }

    private async void OnBackgroundTapped(object? sender, TappedEventArgs e)
    {
        Unfocus();
        CommentEditor.Unfocus();
        await CommentEditor.HideKeyboardAsync();
    }

    private async void OnExpandedChangedComment(object? sender, ExpandedChangedEventArgs e)
    {
        if (e.IsExpanded)
        {
            await ArrowLabelComment.RotateTo(90, 150, Easing.CubicOut);
        }
        else
        {
            await ArrowLabelComment.RotateTo(0, 150, Easing.CubicIn);
        }
    }
    private async void OnExpandedChangedHistory(object? sender, ExpandedChangedEventArgs e)
    {
        if (e.IsExpanded)
        {
            await ArrowLabelVerlauf.RotateTo(90, 150, Easing.CubicOut);
        }
        else
        {
            await ArrowLabelVerlauf.RotateTo(0, 150, Easing.CubicIn);
        }
    }
}
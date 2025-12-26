using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workout.Data;
using Workout.ViewModels;

namespace Workout.Views;

public partial class ExercisePage : ContentPage
{
    public ExercisePage(ExerciseViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
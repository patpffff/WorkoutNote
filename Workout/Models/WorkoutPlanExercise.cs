using SQLite;

namespace Workout.Models;

public class WorkoutPlanExercise
{
    [PrimaryKey, AutoIncrement]
    public int WorkoutPlanExerciseId { get; set; }
    public int WorkoutPlanID { get; set; }  
    public int ExerciseID { get; set; }    
    public int OrderIndex { get; set; }     
}
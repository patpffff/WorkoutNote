using SQLite;
namespace Workout.Models;

public class Exercise
{
    [PrimaryKey, AutoIncrement]
    public int ExerciseID { get; set; }
    public string Name { get; set; }
    public string Comment { get; set; }
}
using SQLite;
namespace Workout.Models;

public class SetEntry
{
    [PrimaryKey, AutoIncrement]
    public int SetEntryId { get; set; }
    public int ExerciseId { get; set; }
    public int setNumber { get; set; }
    public float? weight { get; set; }
    public int? repetitions { get; set; }
    public DateTime performedAt { get; set; }
}
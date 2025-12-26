using SQLite;
using Workout.Models;

namespace Workout.Data;

public class WorkoutDatabase
{
    SQLiteAsyncConnection database;
    
    async Task Init()
    {
        if (database is not null)
            return;

        database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        await database.CreateTableAsync<WorkoutPlan>();
        await database.CreateTableAsync<WorkoutPlanExercise>();
        await database.CreateTableAsync<Exercise>();
        await database.CreateTableAsync<SetEntry>();
    }

    public async Task<List<WorkoutPlan>> GetWorkoutPlanAsync()
    {
        await Init();
        return await database.Table<WorkoutPlan>().ToListAsync();
    }
    
    public async Task<List<Exercise>> GetExerciseAsync()
    {
        await Init();
        return await database.Table<Exercise>().ToListAsync();
    }
    
    public async Task<List<WorkoutPlanExercise>> GetWorkoutPlanExercise(int workoutPlanId)
    {
        await Init();
        return await database
            .Table<WorkoutPlanExercise>()
            .Where(wpe => wpe.WorkoutPlanID == workoutPlanId)
            .ToListAsync();
    }

    public async Task SaveWorkoutPlanAsync(WorkoutPlan workoutPlan)
    {
        await Init();

        if (workoutPlan.WorkoutID != 0)
            await database.UpdateAsync(workoutPlan);
        else
            await database.InsertAsync(workoutPlan);
    }
    public async Task DeleteWorkoutPlanAsync(WorkoutPlan workoutPlan)
    {
        await Init();
        await database.DeleteAsync(workoutPlan);
    }
    
    public async Task SaveExerciseAsync(Exercise exercise)
    {
        await Init();

        if (exercise.ExerciseID != 0)
            await database.UpdateAsync(exercise);
        else
            await database.InsertAsync(exercise);
    }

}
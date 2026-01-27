using SQLite;
using Workout.Models;
using Workout.Views.view;

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
        return await database.Table<Exercise>().OrderBy(exercise => exercise.Name).ToListAsync();
    }
    
    public async Task<List<WorkoutPlanExercise>> GetWorkoutPlanExercise(int workoutPlanId)
    {
        await Init();
        return await database
            .Table<WorkoutPlanExercise>()
            .Where(wpe => wpe.WorkoutPlanID == workoutPlanId).OrderBy(exercise => exercise.OrderIndex )
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
    
    public async Task DeleteWorkoutPlanExerciseAsync(WorkoutPlanExerciseView workoutPlanExerciseView)
    {
        await Init();
        await database.Table<WorkoutPlanExercise>().DeleteAsync(wpe => wpe.WorkoutPlanExerciseId == workoutPlanExerciseView.WorkoutPlanExerciseId);
    }

    public async Task DeleteExerciseAsync(Exercise exercise)
    {
        await  Init();
        await database.Table<SetEntry>().DeleteAsync(entry => entry.ExerciseId == exercise.ExerciseID);
        await database.DeleteAsync(exercise);
    }
    
    public async Task SaveExerciseAsync(Exercise exercise)
    {
        await Init();

        if (exercise.ExerciseID != 0)
            await database.UpdateAsync(exercise);
        else
            await database.InsertAsync(exercise);
    }

    public async Task<Exercise> GetExerciseFromId(int  exerciseId)
    {
        await Init();
        return await database.Table<Exercise>().FirstOrDefaultAsync(exercise => exercise.ExerciseID == exerciseId);
    }
    public async Task AddWorkoutPlanExercise(WorkoutPlanExercise workoutPlanExercise)
    {
        await Init();
        if (workoutPlanExercise.WorkoutPlanExerciseId != 0)
            await database.UpdateAsync(workoutPlanExercise);
        else
            await database.InsertAsync(workoutPlanExercise);
    }

    public async Task AddSetEntryAsync(SetEntry setEntry)
    {
        await Init();
        if (setEntry.SetEntryId != 0)
            await database.UpdateAsync(setEntry);
        else
            await database.InsertAsync(setEntry);
    }

    public async Task<List<SetEntry>> GetSetEntry(int exerciseId)
    {
        await Init();
        return await database.Table<SetEntry>().Where(x => x.ExerciseId == exerciseId)
            .OrderByDescending(x => x.performedAt).ToListAsync();
    }

    public async Task SaveExerciseComment(Exercise exercise)
    {
        await database.UpdateAsync(exercise);
    }
}
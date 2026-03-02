using Garmin.Connect;
using GarminTools.Infrastructure.GarminApi.Models;

namespace GarminTools.Infrastructure.GarminApi.Client;

public class GarminToolsApiClient(GarminConnectContext garminConnectContext)
    : GarminConnectClient(garminConnectContext), IGarminToolsApiClient
{
    private readonly GarminConnectContext _garminConnectContext = garminConnectContext;
    
    private const string CourseUrl = "/course-service/course";
    private const string WorkoutUrl = "workout-service/workout";

    public Task RemoveWorkoutAsync(long workoutId, CancellationToken cancellationToken) =>
        _garminConnectContext.MakeHttpDelete($"/{WorkoutUrl}/{workoutId}", null, cancellationToken);

    public Task<Course[]> GetCoursesAsync(CancellationToken cancellationToken) =>
        _garminConnectContext.GetAndDeserialize<Course[]>(CourseUrl, cancellationToken);

    public async Task RemoveCoursesAsync(long[] coursesIds, CancellationToken cancellationToken)
    {
        ParallelOptions parallelOptions = new()
        {
            CancellationToken = cancellationToken,
            MaxDegreeOfParallelism = 5,
        };

        await Parallel.ForEachAsync(coursesIds, parallelOptions,
            async (id, token) => { await _garminConnectContext.MakeHttpDelete($"{CourseUrl}/{id}", null, token); });
    }

    public async Task<(bool, string)> ValidateLoginAsync(CancellationToken cancellationToken)
    {
        try
        {
            await _garminConnectContext.ReLoginIfExpired(true, cancellationToken);
            return (true, string.Empty);
        }
        catch (Exception e)
        {
            return string.Equals(
                e.Message,
                "Failed to find regex match for ticket.",
                StringComparison.InvariantCultureIgnoreCase)
                ? (false, "Invalid credentials")
                : (false, e.Message);
        }
    }
}
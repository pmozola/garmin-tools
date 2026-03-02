using Garmin.Connect;
using GarminTools.Infrastructure.GarminApi.Models;

namespace GarminTools.Infrastructure.GarminApi.Client;

public interface IGarminToolsApiClient : IGarminConnectClient
{
    Task RemoveWorkoutAsync(long workoutId, CancellationToken cancellationToken);
    Task<Course[]> GetCoursesAsync(CancellationToken cancellationToken);
    Task RemoveCoursesAsync(long[] coursesIds, CancellationToken cancellationToken);
    Task<(bool, string)> ValidateLoginAsync(CancellationToken cancellationToken);
}
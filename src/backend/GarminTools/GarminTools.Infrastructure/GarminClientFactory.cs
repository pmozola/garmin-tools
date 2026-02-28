using Garmin.Connect;
using Garmin.Connect.Auth;

namespace GarminTools.Infrastructure;

public class GarminClientFactory
{
    public IGarminToolsApiClient Get(string userName, string password)
    {
        return new GarminToolsApiClient(new GarminConnectContext(new HttpClient(),
            new BasicAuthParameters(userName, password)));
    }
}

public class GarminToolsApiClient(GarminConnectContext garminConnectContext) : GarminConnectClient(garminConnectContext), IGarminToolsApiClient
{
    private readonly string _workoutUrl = "workout-service/workout";
    private readonly string _courseUrl = "/course-service/course";

    public async Task RemoveWorkout(long workoutId, CancellationToken cancellationToken)
    {
        var result = await garminConnectContext.MakeHttpDelete($"/{_workoutUrl}/{workoutId}", null, cancellationToken);
        return;
    }

    public async Task<Course[]> GetCourses(CancellationToken cancellationToken)
    {
        var result3 = await garminConnectContext.GetAndDeserialize<Course[]>(_courseUrl, cancellationToken);

        return result3;
    }

    public async Task RemoveCourses(long[] coursesIds, CancellationToken cancellationToken)
    {
        try
        {
            foreach (var course in coursesIds)
            {
                await garminConnectContext.MakeHttpDelete($"{_courseUrl}/{course}", null, cancellationToken);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }

    public async Task<(bool, string)> ValidateLogin(CancellationToken cancellationToken)
    {
        try
        {
            await garminConnectContext.ReLoginIfExpired(force: true, cancellationToken);
            return (true, string.Empty);
        }
        catch (Exception e)
        {
            return string.Equals(e.Message, "Failed to find regex match for ticket.", StringComparison.InvariantCultureIgnoreCase) ? 
                (false, "Invalid credentials") : 
                (false, e.Message);
        }
    }
}

public interface IGarminToolsApiClient : IGarminConnectClient
{
    Task RemoveWorkout(long workoutId, CancellationToken cancellationToken);
    Task<Course[]> GetCourses(CancellationToken cancellationToken);
    Task RemoveCourses(long[] coursesIds, CancellationToken cancellationToken);

    Task<(bool, string)> ValidateLogin(CancellationToken cancellationToken);
}
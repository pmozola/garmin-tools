using Garmin.Connect.Parameters;
using GarminTools.Infrastructure;
using MediatR;

namespace GarminTools.Application.Handlers.Queries;

public class GetAllWorkoutsQueryHandler(IGarminToolsApiClient client): IRequestHandler<GetAllWorkoutsQuery, WorkoutInformationResponse[]>
{
    public async Task<WorkoutInformationResponse[]> Handle(GetAllWorkoutsQuery request, CancellationToken cancellationToken)
    {
        var result = await client.GetWorkouts(new WorkoutsParameters(),cancellationToken);
        
        return result.Select(x => new WorkoutInformationResponse(x.WorkoutId, x.WorkoutName)).ToArray();
    }
}

public record GetAllWorkoutsQuery : IRequest<WorkoutInformationResponse[]>;
public record WorkoutInformationResponse(long WorkoutId, string Name);
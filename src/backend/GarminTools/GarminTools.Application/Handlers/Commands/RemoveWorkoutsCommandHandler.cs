using GarminTools.Infrastructure;
using MediatR;

namespace GarminTools.Application.Handlers.Commands;

public class RemoveWorkoutsCommandHandler(IGarminToolsApiClient client) : IRequestHandler<RemoveWorkoutsCommand>
{
    public async Task Handle(RemoveWorkoutsCommand request, CancellationToken cancellationToken)
    {
       foreach (var requestActivitiesId in request.ActivitiesIds)
       {
           await client.RemoveWorkout(requestActivitiesId, cancellationToken);
       }
    }
}

public record RemoveWorkoutsCommand(long[] ActivitiesIds) : IRequest;
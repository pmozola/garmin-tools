using GarminTools.Application.Handlers.Queries;
using GarminTools.Infrastructure;
using MediatR;

namespace GarminTools.Application.Handlers.Commands;

public class RemoveWorkoutsCommandHandler : IRequestHandler<RemoveWorkoutsCommand>
{
    public async Task Handle(RemoveWorkoutsCommand request, CancellationToken cancellationToken)
    {
       var client = new GarminClientFactory().Get(request.GarminAuthentication.Email, request.GarminAuthentication.Password);

       foreach (var requestActivitiesId in request.ActivitiesIds)
       {
           await client.RemoveWorkout(requestActivitiesId, cancellationToken);
       }
    }
}

public record RemoveWorkoutsCommand(GarminAuthentication  GarminAuthentication, long[] ActivitiesIds) : IRequest<GetUserDevicesQueryResponse[]>, IRequest;
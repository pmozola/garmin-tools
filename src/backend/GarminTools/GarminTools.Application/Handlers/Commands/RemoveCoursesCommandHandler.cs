using GarminTools.Infrastructure;
using GarminTools.Infrastructure.GarminApi;
using GarminTools.Infrastructure.GarminApi.Client;
using MediatR;

namespace GarminTools.Application.Handlers.Commands;

public class RemoveCoursesCommandHandler(IGarminToolsApiClient client) : IRequestHandler<RemoveCoursesCommand>
{
    public Task Handle(RemoveCoursesCommand request, CancellationToken cancellationToken) =>
         client.RemoveCoursesAsync(request.CoursesIds, cancellationToken);
}

public record RemoveCoursesCommand(long[] CoursesIds) :IRequest;

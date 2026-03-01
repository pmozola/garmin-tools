using GarminTools.Infrastructure;
using MediatR;

namespace GarminTools.Application.Handlers.Commands;

public class RemoveCoursesCommandHandler(IGarminToolsApiClient client) : IRequestHandler<RemoveCoursesCommand>
{
    public Task Handle(RemoveCoursesCommand request, CancellationToken cancellationToken) =>
         client.RemoveCourses(request.CoursesIds, cancellationToken);
}

public record RemoveCoursesCommand(long[] CoursesIds) :IRequest;

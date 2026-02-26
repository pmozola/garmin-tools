using GarminTools.Application.Handlers.Queries;
using GarminTools.Infrastructure;
using MediatR;

namespace GarminTools.Application.Handlers.Commands;

public class RemoveCoursesCommandHandler : IRequestHandler<RemoveCoursesCommand>
{
    public Task Handle(RemoveCoursesCommand request, CancellationToken cancellationToken)
    {
        return new GarminClientFactory().Get(request.Authentication.Email, request.Authentication.Password).RemoveCourses(request.CoursesIds, cancellationToken);
    }
}

public record RemoveCoursesCommand(GarminAuthentication Authentication, long[] CoursesIds) : IRequest;
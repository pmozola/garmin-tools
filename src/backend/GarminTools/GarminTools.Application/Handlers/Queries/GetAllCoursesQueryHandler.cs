using GarminTools.Infrastructure;
using MediatR;

namespace GarminTools.Application.Handlers.Queries;

public class GetAllCoursesQueryHandler : IRequestHandler<GetAllCoursesQuery, GetAllCoursesQueryResponse[]>
{
    public async Task<GetAllCoursesQueryResponse[]> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
    {
       var result = await new GarminClientFactory().Get(request.Auth.Email, request.Auth.Password).GetCourses(cancellationToken);

       return result.Select(x => new GetAllCoursesQueryResponse(x.CourseName, x.CourseId)).ToArray();
    }
}

public record GetAllCoursesQuery(GarminAuthentication Auth) : IRequest<GetAllCoursesQueryResponse[]>;

public record GetAllCoursesQueryResponse(string Name, long Id);
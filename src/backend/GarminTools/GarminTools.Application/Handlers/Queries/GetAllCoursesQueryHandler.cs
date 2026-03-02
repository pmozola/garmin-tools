using GarminTools.Infrastructure;
using GarminTools.Infrastructure.GarminApi;
using GarminTools.Infrastructure.GarminApi.Client;
using MediatR;

namespace GarminTools.Application.Handlers.Queries;

public class GetAllCoursesQueryHandler(IGarminToolsApiClient client) : IRequestHandler<GetAllCoursesQuery, GetAllCoursesQueryResponse[]>
{
    public async Task<GetAllCoursesQueryResponse[]> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
    {
       var result = await client.GetCoursesAsync(cancellationToken);

       return result.Select(x => new GetAllCoursesQueryResponse(
           x.CourseName,
           x.CourseId,
           x.CreatedDateFormatted, 
           x.DistanceInMeters, 
           x.ElevationGainInMeters)).ToArray();
    }
}

public record GetAllCoursesQuery : IRequest<GetAllCoursesQueryResponse[]>;

public record GetAllCoursesQueryResponse(string Name, long Id, string CreatedAt, double DistanceInMeters, double ElevationGainInMeters);
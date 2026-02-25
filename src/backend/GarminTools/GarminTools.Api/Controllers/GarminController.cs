using GarminTools.Application.Handlers.Commands;
using GarminTools.Application.Handlers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GarminTools.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class GarminController(ISender sender) : ControllerBase
{
    [HttpGet("devices")]
    public Task<GetUserDevicesQueryResponse[]> GetDevices([FromQuery]GetUserDevicesQuery query, CancellationToken cancellationToken)
    {
        return sender.Send(query, cancellationToken);
    }
    
    [HttpGet("workouts")]
    public Task<WorkoutInformationResponse[]> GetWorkouts([FromQuery]GetAllWorkoutsQuery query, CancellationToken cancellationToken)
    {
        return sender.Send(query, cancellationToken);
    }
    
    [HttpGet("cources")]
    public Task<GetAllCoursesQueryResponse[]> GetCourses([FromQuery]GetAllCoursesQuery query, CancellationToken cancellationToken)
    {
        return sender.Send(query, cancellationToken);
    }
    
    [HttpDelete("cources")]
    public Task DeleteCourses([FromBody]RemoveCoursesCommand command, CancellationToken cancellationToken)
    {
        return sender.Send(command, cancellationToken);
    }
    
    [HttpDelete("workouts")]
    public Task DeleteWorkouts([FromBody]RemoveWorkoutsCommand command, CancellationToken cancellationToken)
    {
        return sender.Send(command, cancellationToken);
    }
}
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
    
    [HttpGet("courses")]
    public Task<GetAllCoursesQueryResponse[]> GetCourses(CancellationToken cancellationToken)
    {
        return sender.Send(new GetAllCoursesQuery(), cancellationToken);
    }
    
    [HttpDelete("courses")]
    public Task DeleteCourses([FromBody]RemoveCoursesCommand command, CancellationToken cancellationToken)
    {
        return sender.Send(command, cancellationToken);
    }
    
    [HttpDelete("workouts")]
    public Task DeleteWorkouts([FromBody]RemoveWorkoutsCommand command, CancellationToken cancellationToken)
    {
        return sender.Send(command, cancellationToken);
    }
    
    [HttpPost("credentials")]
    public Task<VerifyCredentialsCommandResponse> ValidateCredentials(VerifyCredentialsRequest command, CancellationToken cancellationToken)
    {
        return sender.Send(new VerifyCredentialsCommand(new GarminAuthentication(command.Email, command.Password)), cancellationToken);
    }
    
    public record VerifyCredentialsRequest(string Email, string Password);
}
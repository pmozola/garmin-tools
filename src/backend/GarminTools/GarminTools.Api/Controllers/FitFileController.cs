using GarminTools.Application.Handlers.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GarminTools.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class FitFileController(ISender sender) : ControllerBase
{
    [HttpPost("change")]
    public async Task<IActionResult> ChangeDevice([FromForm]ChangeDeviceRequest data,  CancellationToken cancellationToken)
    {
        using var stream = new MemoryStream();
        await data.File.CopyToAsync(stream, cancellationToken);
        var fileContents = stream.ToArray();

        var result = await sender.Send(new ChangeDeviceInFitFileCommand(fileContents, data.DeviceId), cancellationToken);

        return new FileContentResult(result, "application/octet-stream"){FileDownloadName = $"{Guid.NewGuid()}.fit"};
    }
    
   
    
    public class ChangeDeviceRequest
    {
        public IFormFile File { get; set; } = null!;
        public long? DeviceId { get; set; }
    }
}
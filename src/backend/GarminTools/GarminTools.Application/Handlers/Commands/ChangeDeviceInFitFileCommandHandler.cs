using Dynastream.Fit;
using Garmin.Connect;
using GarminTools.Infrastructure.FitFile;
using GarminTools.Infrastructure.GarminApi.Client;
using MediatR;
using File = Dynastream.Fit.File;

namespace GarminTools.Application.Handlers.Commands;

public class ChangeDeviceInFitFileCommandHandler(IGarminToolsApiClient client) : IRequestHandler<ChangeDeviceInFitFileCommand, byte[]>
{
    public async Task<byte[]> Handle(ChangeDeviceInFitFileCommand request, CancellationToken cancellationToken)
    {

        if (request.DeviceId != null)
        {
            var devices =await client.GetDevices(cancellationToken);
            var userDevice = devices.FirstOrDefault(x => x.DeviceId == request.DeviceId);
            if (userDevice == null) throw new ArgumentException("device not found");

           var device =  new GarminDeviceToChange(
                Manufacturer: Manufacturer.Garmin,
                Product: Convert.ToUInt16( userDevice.DeviceTypePk),
                Name: userDevice.DisplayName,
                SerialNumber: Convert.ToUInt32(userDevice.DeviceId),
                Type: File.Activity);
             
             return new FitFileService().Convert(request.FileContents, device);
            
            
        }
        var result =  new FitFileService().Convert(request.FileContents);
        return result;
    }
}

public record ChangeDeviceInFitFileCommand(byte[] FileContents, long? DeviceId) : IRequest<byte[]>;
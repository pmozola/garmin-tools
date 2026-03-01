using GarminTools.Infrastructure;
using MediatR;

namespace GarminTools.Application.Handlers.Queries;

public class GetUserDevicesQueryHandler(IGarminToolsApiClient client) : IRequestHandler<GetUserDevicesQuery,GetUserDevicesQueryResponse[]>
{
    public async Task<GetUserDevicesQueryResponse[]> Handle(GetUserDevicesQuery request, CancellationToken cancellationToken)
    {
        var devices = await client.GetDevices(cancellationToken);

        return devices.OrderBy(x => x.Primary)
            .Select(x => new GetUserDevicesQueryResponse(x.DisplayName, x.DeviceId, x.DeviceTypePk)).ToArray();
    }
}


public record GetUserDevicesQuery: IRequest<GetUserDevicesQueryResponse[]>;


public record GarminAuthentication(string Email, string Password);
public record GetUserDevicesQueryResponse(string DeviceName, long SerialNumber, long TypeId);
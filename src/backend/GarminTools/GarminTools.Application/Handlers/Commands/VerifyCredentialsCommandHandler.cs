using GarminTools.Application.Handlers.Queries;
using GarminTools.Infrastructure;
using MediatR;

namespace GarminTools.Application.Handlers.Commands;


public class VerifyCredentialsCommandHandler : IRequestHandler<VerifyCredentialsCommand,VerifyCredentialsCommandResponse>
{
    public async Task<VerifyCredentialsCommandResponse> Handle(VerifyCredentialsCommand request, CancellationToken cancellationToken)
    {
        var result  = await new GarminClientFactory()
            .Get(request.GarminAuthentication.Email, request.GarminAuthentication.Password).ValidateLogin(cancellationToken);

        return new VerifyCredentialsCommandResponse(result.Item1, result.Item2);
    }
}

public record VerifyCredentialsCommand(GarminAuthentication GarminAuthentication) : IRequest<VerifyCredentialsCommandResponse>;

public record VerifyCredentialsCommandResponse(bool IsValid, string ErrorMessage);
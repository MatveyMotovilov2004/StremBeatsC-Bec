using Grpc.Core;
using Identity.Application.Logout;
using LogoutGrpc;
using MediatR;

namespace Identity.GrpcServices;

public class LogoutService 
    : LogoutGrpcService.LogoutGrpcServiceBase
{
    private readonly IMediator _mediator;
    public LogoutService(IMediator mediator)
    {
        _mediator = mediator;
    }
    public override async Task<LogoutResponse> Logout(
        LogoutRequest request, ServerCallContext context)
    {
        return await _mediator.Send(new LogoutCommand(
            request.RefreshToken));
    }
}

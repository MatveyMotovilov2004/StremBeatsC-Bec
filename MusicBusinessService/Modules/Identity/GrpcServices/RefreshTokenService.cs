using Grpc.Core;
using Identity.Application;
using MediatR;
using RefreshTokenGrpc;

namespace Identity.GrpcServices;

public class RefreshTokenService 
    : RefreshTokenGrpcServise.RefreshTokenGrpcServiseBase
{
    private readonly IMediator _mediator;
    public RefreshTokenService(IMediator mediator)
    {
        _mediator = mediator;
    }
    public override async Task<RefreshTokenRespounse> RefreshToken(
        RefreshTokenRequest request, ServerCallContext context)
    {
        return await _mediator.Send(
            new RefreshTokenCommand(
                request.RefreshToken));
    }
}

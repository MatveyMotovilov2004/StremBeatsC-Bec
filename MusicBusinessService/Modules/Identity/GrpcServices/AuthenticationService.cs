using Grpc.Core;
using Identity.Application;
using MediatR;
using AuthenticationGrpc;

namespace Identity.GrpcServices;

public class AuthenticationService 
    : AuthenticationGrpcService.AuthenticationGrpcServiceBase
{
    private readonly IMediator _mediator;
    public AuthenticationService(IMediator mediator)
    {
        _mediator = mediator;
    }
    public override async Task<AuthenticationResponse> Authentication(
        AuthenticationRequest request, ServerCallContext context)
    {
        return await _mediator.Send(
            new AuthenticationCommand(
                request.Email, request.Password));
    }
}

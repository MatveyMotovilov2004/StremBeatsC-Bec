using MediatR;
using GiveRoleGrpc;
using Grpc.Core;
using Identity.Application.GiveRole;

namespace Identity.GrpcServices
{
    public class GiveRoleService : GiveRoleGrpcService.GiveRoleGrpcServiceBase
    {
        private readonly IMediator _mediator;

        public GiveRoleService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public override async Task<GiveRoleArtistResponse> GiveRoleArtist(
            GiveRoleArtistRequest request, ServerCallContext context)
        {
            return await _mediator.Send(
                new GiveRoleCommand(
                    request.UserId));
        }
    }
}

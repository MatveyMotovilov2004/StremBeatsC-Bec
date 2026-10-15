using MediatR;
using GiveRoleGrpc;

namespace Identity.Application.GiveRole
{
    public record GiveRoleCommand(int userId)
        : IRequest<GiveRoleArtistResponse>;
}

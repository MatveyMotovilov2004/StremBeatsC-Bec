using GiveRoleGrpc;
using Identity.Application.Services.InfrastructureContract;
using Identity.Domain;
using Identity.Infrastructure.Persistence;
using MediatR;

namespace Identity.Application.GiveRole
{
    public class GiveRoleHandler 
        : IRequestHandler<GiveRoleCommand, GiveRoleArtistResponse> 
    {
        private readonly IUserReader _userReader;
        private readonly IRoleReader _roleReader;
        private readonly IdentityDbContext _db;

        public GiveRoleHandler(
            IUserReader userReader,
            IRoleReader roleReader,
            IdentityDbContext db)
        {
            _userReader = userReader;
            _roleReader = roleReader;
            _db = db;
        }
        public async Task<GiveRoleArtistResponse> Handle(
            GiveRoleCommand request, CancellationToken ct)
        {
            var user = await _userReader.FindByIdAsync(request.userId, ct);
            if (user is null)
                throw new InvalidOperationException("Invalid credentials.");

            var role = await _roleReader.FindByTypeAsync(RoleType.Artist, ct);
            if (user.Roles.Any(x => x.Type == RoleType.Artist))
                return new GiveRoleArtistResponse();

            user.Roles.Add(role);
            return new GiveRoleArtistResponse();
        }
    }
}

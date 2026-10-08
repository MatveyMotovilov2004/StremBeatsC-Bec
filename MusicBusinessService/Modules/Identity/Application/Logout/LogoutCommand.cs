using LogoutGrpc;
using MediatR;

namespace Identity.Application.Logout;

public record LogoutCommand(string refreshToken)
    : IRequest<LogoutResponse>;

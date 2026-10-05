using MediatR;
using RefreshTokenGrpc;

namespace Identity.Application;

public record RefreshTokenCommand(string refreshToken)
    : IRequest<RefreshTokenRespounse>;


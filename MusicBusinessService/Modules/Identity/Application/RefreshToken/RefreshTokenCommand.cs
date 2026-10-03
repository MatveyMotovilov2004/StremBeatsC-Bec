using MediatR;
using RefreshTokenGrpc;

namespace Identity.Application.RefreshToken;

public class RefreshTokenCommand(string RefreshToken)
    : IRequest<RefreshTokenRespounse>;


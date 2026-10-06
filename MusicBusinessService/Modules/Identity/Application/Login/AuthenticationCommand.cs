using AuthenticationGrpc;
using MediatR;

namespace Identity.Application.Login;

public record AuthenticationCommand(string email, string password)
    : IRequest<AuthenticationResponse>;

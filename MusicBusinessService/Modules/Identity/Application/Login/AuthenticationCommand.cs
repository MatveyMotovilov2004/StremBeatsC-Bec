using AuthenticationGrpc;
using MediatR;

namespace Identity.Application;

public record AuthenticationCommand(string email, string password)
    : IRequest<AuthenticationResponse>;

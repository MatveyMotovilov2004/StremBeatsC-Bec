using MediatR;
using Register;

namespace Identity.Application.Register;

public record class RegisterCommand
    (string userName, string email, string passwordHash) 
    : IRequest<RegisterUserRespounse>;


using MediatR;

namespace Identity.Application.Register;

public record class RegisterCommand
    (string email, string passwordHash) : IRequest<int>;


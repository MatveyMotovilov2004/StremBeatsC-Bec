using Grpc.Core;
using MediatR;
using Identity.Application.Register;
using Register;
//using User;

namespace Identity.GrpcServices
{
    public class RegisterService : RegisterGrpcServise.RegisterGrpcServiseBase
    {
        private readonly IMediator _mediator;

        public RegisterService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task<RegisterUserRespounse> RegisterUser
            (RegisterUserRequest request, ServerCallContext context)
        {
            return await _mediator.Send(
                new RegisterCommand(
                    request.Username, request.Email, request.Password
            ));
        }
    }
}

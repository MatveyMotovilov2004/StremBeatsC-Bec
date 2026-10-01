using Grpc.Core;
using MediatR;
using Identity.Application.Register;
using Register;
//using User;

namespace MusicBusinessService.Modules.Identity.GrpcServices
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
            var result = await _mediator.Send(
                new RegisterCommand(
                    request.Email, request.PasswordHash
            ));
            return new RegisterUserRespounse
            {
                //UserId = result.id,

            };
        }
    }
}

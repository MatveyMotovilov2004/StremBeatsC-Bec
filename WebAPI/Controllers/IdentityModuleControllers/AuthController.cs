using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Register;

namespace WebAPI.Controllers.IdentityModuleControllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly RegisterGrpcServise.RegisterGrpcServiseClient  _mbsRegisterClient;
    
    public AuthController(
        RegisterGrpcServise.RegisterGrpcServiseClient mbsRegisterClient)
    {
        _mbsRegisterClient = mbsRegisterClient;
    }
    [HttpPost]
    public async Task<IActionResult> RegisterUser(
        [FromBody] RegisterUserRequest request,
        CancellationToken token)
    {
        // TODO: remove for production
        var httpHandler = new HttpClientHandler();
        httpHandler.ServerCertificateCustomValidationCallback =
            HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

        var respounse = await _mbsRegisterClient.RegisterUserAsync(
            request, cancellationToken : token);

        return Ok(respounse);
    }
}

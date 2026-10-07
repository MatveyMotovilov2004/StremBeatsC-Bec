using AuthenticationGrpc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using RefreshTokenGrpc;
using Register;


namespace WebAPI.Controllers.IdentityModuleControllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly RegisterGrpcServise.RegisterGrpcServiseClient  _mbsRegisterClient;
    private readonly RefreshTokenGrpcServise.RefreshTokenGrpcServiseClient _mbsRefreshTokenClient;
    private readonly AuthenticationGrpcService.AuthenticationGrpcServiceClient _mbcAuthenticationClient;
    public AuthController(
        RegisterGrpcServise.RegisterGrpcServiseClient mbsRegisterClient,
        RefreshTokenGrpcServise.RefreshTokenGrpcServiseClient mbsRefreshTokenClient,
        AuthenticationGrpcService.AuthenticationGrpcServiceClient mbcAuthenticationClient)
    {
        _mbsRegisterClient = mbsRegisterClient;
        _mbsRefreshTokenClient = mbsRefreshTokenClient;
        _mbcAuthenticationClient = mbcAuthenticationClient;
    }

    [HttpPost("register")]
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

    [HttpPost("refreshToken")]
    public async Task<IActionResult> RefreshToken(
        [FromBody] RefreshTokenRequest request,
        CancellationToken token)
    {
        // TODO: remove for production
        var httpHandler = new HttpClientHandler();
        httpHandler.ServerCertificateCustomValidationCallback =
            HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

        var response = await _mbsRefreshTokenClient.RefreshTokenAsync(
            request, cancellationToken: token);

        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(
        [FromBody] AuthenticationRequest request,
        CancellationToken token)
    {
        var response = await _mbcAuthenticationClient.AuthenticationAsync(
            request, cancellationToken: token);
        return Ok(response);
    } 
}


using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using WebAPI.Authentication;
using WebAPI.Diagnostics;
using WebAPI.GrpcClientRegistration;


namespace WebAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        builder.Services.AddSwaggerGen();

        builder.Services.AddEndpointsApiExplorer();
        // Add services validator
        builder.Services.AddValidatorsFromAssemblyContaining<Program>();
        // launching the autopipeline SharpGrip
        builder.Services.AddFluentValidationAutoValidation(configuration =>
        {
            // Disable the built-in .NET model (data annotations) validation.
            configuration.DisableBuiltInModelValidation = true;
        });

        builder.Services.AddBusinessLogicGrpcClient(builder.Configuration);
        builder.Services.AddGoGrpcClients();
        builder.Services.AddOrchestrator();

        builder.Services.AddApiAuthentication(builder.Configuration);

        builder.Services.AddProblemDetails();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();

        app.UseExceptionHandler();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapDiagnosticEndpoints();

        app.Run();
    }
}


using FluentValidation;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Identity;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using Tracks;
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

        builder.Services.AddBusinessLogicGrpcClient();
        builder.Services.AddGoGrpcClients();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}

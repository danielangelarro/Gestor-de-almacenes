using Microsoft.Extensions.DependencyInjection;
using GestorDeAlmacenes.Application.Authentication.Queries.Login;
using GestorDeAlmacenes.Application.Authentication.Commands.Register;
using GestorDeAlmacenes.Application.Authentication.Services;
using FluentValidation;

namespace GestorDeAlmacenes.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

        services.AddScoped<IValidator<RegisterCommand>, RegisterCommandValidator>();
        services.AddScoped<IValidator<LoginQuery>, LoginQueryValidator>();

        services.AddScoped<PasswordService>();

        return services;
    }
}
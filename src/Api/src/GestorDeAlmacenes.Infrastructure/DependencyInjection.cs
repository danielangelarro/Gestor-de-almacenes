using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.Common.Interfaces.Authentication;
using GestorDeAlmacenes.Application.Common.Interfaces.Repository;
using GestorDeAlmacenes.Application.Common.Interfaces.Services;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Infrastructure.Authentication;
using GestorDeAlmacenes.Infrastructure.Repositories;
using GestorDeAlmacenes.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GestorDeAlmacenes.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        Microsoft.Extensions.Configuration.ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

        services.AddDbContext<GestorDeAlmacenesDBContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                x => x.MigrationsAssembly("GestorDeAlmacenes.API")
            )
        );

        services.AddSingleton<IJwtTokenGenerator, JwTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<ICasilleroRepository, CasilleroRepository>();
        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<IEntradaRepository, EntradaRepository>();
        services.AddScoped<IMermaRepository, MermaRepository>();
        services.AddScoped<IPhotoRepository, PhotoRepository>();
        services.AddScoped<IProductoRepository, ProductoRepository>();
        services.AddScoped<IProveedorRepository, ProveedorRepository>();
        services.AddScoped<IRackRepository, RackRepository>();
        services.AddScoped<ISalidaRepository, SalidaRepository>();
        services.AddScoped<IUbicacionRepository, UbicacionRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
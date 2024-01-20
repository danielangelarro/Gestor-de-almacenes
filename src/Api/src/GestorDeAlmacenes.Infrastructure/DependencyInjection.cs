using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.Common.Interfaces.Authentication;
using GestorDeAlmacenes.Application.Common.Interfaces.Repository;
using GestorDeAlmacenes.Application.Common.Interfaces.Services;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Application.Services;
using GestorDeAlmacenes.Infrastructure.Authentication;
using GestorDeAlmacenes.Infrastructure.Repositories;
using GestorDeAlmacenes.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GestorDeAlmacenes.Infrastructure;


public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<GestorDeAlmacenesDBContext>
{
    public GestorDeAlmacenesDBContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(@Directory.GetCurrentDirectory() + "/../GestorDeAlmacenes.API/appsettings.Development.json")
            .Build();
        var builder = new DbContextOptionsBuilder<GestorDeAlmacenesDBContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        builder.UseNpgsql(connectionString);
        return new GestorDeAlmacenesDBContext(builder.Options);
    }
}


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
        services.AddScoped<IMovimientoRepository, MovimientoRepository>();
        services.AddScoped<IMermaRepository, MermaRepository>();
        services.AddScoped<IPhotoRepository, PhotoRepository>();
        services.AddScoped<IProductoRepository, ProductoRepository>();
        services.AddScoped<IProveedorRepository, ProveedorRepository>();
        services.AddScoped<IRackRepository, RackRepository>();
        services.AddScoped<ISalidaRepository, SalidaRepository>();
        services.AddScoped<IUbicacionRepository, UbicacionRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUbicacionSalidaRepository, UbicacionSalidaRepository>();

        services.AddScoped<IGetCurrentUserLoginService, GetCurrentUserLoginService>();

        Task.Run(
            () => InitializeDatabase(services.BuildServiceProvider().GetRequiredService<GestorDeAlmacenesDBContext>())
        );

        return services;
    }

    public static async Task InitializeDatabase(GestorDeAlmacenesDBContext context)
    {
        RackRepository rackRepository = new RackRepository(context);
        CasilleroRepository casilleroRepository = new CasilleroRepository(context);

        if (await rackRepository.GetMermaRacksAsync() is not Rack merma_rack)
        {
            merma_rack = new Rack{
                ID_Rack = Guid.NewGuid(),
                Pasillo = "Merma",
                Cantidad_Casillas = 1,
                Filas = 1,
                Columnas = 1,
                Peso_Maximo = float.MaxValue,
                Alto = float.MaxValue,
                Ancho = float.MaxValue,
                Largo = float.MaxValue,
                Unidad_Dimensiones = "m",
                Type = "merma"
            };

            await rackRepository.AddRackAsync(merma_rack);
        }

        if (await rackRepository.GetWaitRacksAsync() is not Rack wait_rack)
        {
            wait_rack = new Rack{
                ID_Rack = Guid.NewGuid(),
                Pasillo = "Wait",
                Cantidad_Casillas = 1,
                Filas = 1,
                Columnas = 1,
                Peso_Maximo = float.MaxValue,
                Alto = float.MaxValue,
                Ancho = float.MaxValue,
                Largo = float.MaxValue,
                Unidad_Dimensiones = "m",
                Type = "wait"
            };

            await rackRepository.AddRackAsync(wait_rack);

            var casillero = new Casillero
            {
                ID_Casillero = Guid.NewGuid(),
                ID_Rack = wait_rack.ID_Rack,
                Index = 1,
                Area = float.MaxValue,
                Peso_Maximo = wait_rack.Peso_Maximo,
                Alto = wait_rack.Alto,
                Ancho = wait_rack.Ancho,
                Largo = wait_rack.Largo,
                Unidad_Dimensiones = wait_rack.Unidad_Dimensiones
            };

            await casilleroRepository.AddCasilleroAsync(casillero);
        }
    }
}
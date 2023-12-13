using GestorDeAlmacenes.Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestorDeAlmacenes.Infrastructure.Repositories;

public class GestorDeAlmacenesDBContext : DbContext
{
    public GestorDeAlmacenesDBContext(DbContextOptions<GestorDeAlmacenesDBContext> options) : base(options)
    {
    }

    public DbSet<User> Users {get; set; }
    public DbSet<Photo> Photos {get; set; }
    public DbSet<Producto> Productos { get; set; }
    public DbSet<Casillero> Casilleros { get; set; }
    public DbSet<Rack> Racks { get; set; }
    public DbSet<Ubicacion> Ubicaciones { get; set; }
    public DbSet<Proveedor> Proveedores { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Merma> Mermas { get; set; }
    public DbSet<Entrada> Entradas { get; set; }
    public DbSet<Salida> Salidas { get; set; }
}
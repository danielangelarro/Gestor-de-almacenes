using GestorDeAlmacenes.Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestorDeAlmacenes.Infrastructure.Repositories;

public class GestorDeAlmacenesDBContext : DbContext
{
    public GestorDeAlmacenesDBContext(DbContextOptions<GestorDeAlmacenesDBContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Entrada>()
            .HasKey(e => new { e.ID_Entrada, e.ID_Producto, e.ID_Usuario });
        
        modelBuilder.Entity<Salida>()
            .HasKey(s => new { s.ID_Salida, s.ID_Producto, s.ID_Usuario });
        
        modelBuilder.Entity<Ubicacion>()
            .HasKey(u => new { u.ID_Producto, u.ID_Casillero });
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
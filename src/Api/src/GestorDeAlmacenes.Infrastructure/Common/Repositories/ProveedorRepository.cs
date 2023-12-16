using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestorDeAlmacenes.Infrastructure.Repositories;

public class ProveedorRepository : IProveedorRepository
{
   private readonly GestorDeAlmacenesDBContext _context;

   public ProveedorRepository(GestorDeAlmacenesDBContext context)
   {
       _context = context;
   }

   public async Task AddProveedorAsync(Proveedor proveedor)
   {
       _context.Proveedores.Add(proveedor);
       await _context.SaveChangesAsync();
   }

   public async Task DeleteProveedorAsync(Proveedor proveedor)
   {
       _context.Proveedores.Remove(proveedor);
       await _context.SaveChangesAsync();
   }

   public async Task<ICollection<Proveedor>> GetAllProveedoresAsync()
   {
       return await _context.Proveedores.ToListAsync();
   }

   public async Task<Proveedor> GetProveedorByIdAsync(Guid id)
   {
       return await _context.Proveedores.FindAsync(id);
   }

   public async Task UpdateProveedorAsync(Proveedor proveedor)
   {
       _context.Proveedores.Update(proveedor);
       await _context.SaveChangesAsync();
   }
}

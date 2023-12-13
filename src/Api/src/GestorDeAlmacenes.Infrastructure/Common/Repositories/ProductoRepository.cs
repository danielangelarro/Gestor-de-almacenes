using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestorDeAlmacenes.Infrastructure.Repositories
{
 public class ProductoRepository : IProductoRepository
 {
   private readonly GestorDeAlmacenesDBContext _context;

   public ProductoRepository(GestorDeAlmacenesDBContext context)
   {
       _context = context;
   }

   public async Task AddProductoAsync(Producto producto)
   {
       await _context.Productos.AddAsync(producto);
       await _context.SaveChangesAsync();
   }

   public async Task DeleteProductoAsync(Producto producto)
   {
       _context.Productos.Remove(producto);
       await _context.SaveChangesAsync();
   }

   public async Task<IEnumerable<Producto>> GetAllProductosAsync()
   {
       return await _context.Productos.ToListAsync();
   }

   public async Task<Producto> GetProductoByIdAsync(Guid id)
   {
       return await _context.Productos.FindAsync(id);
   }

   public async Task UpdateProductoAsync(Producto producto)
   {
       _context.Productos.Update(producto);
       await _context.SaveChangesAsync();
   }
 }
}

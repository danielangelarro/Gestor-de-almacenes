using GestorDeAlmacenes.Application.Entities;

namespace GestorDeAlmacenes.Application.Common.Interfaces;

public interface IProductoRepository
{
  Task<Producto> GetProductoByIdAsync(Guid id);
  Task<List<Producto>> GetAllProductosAsync();
  Task AddProductoAsync(Producto producto);
  Task UpdateProductoAsync(Producto producto);
  Task DeleteProductoAsync(Producto producto);
}
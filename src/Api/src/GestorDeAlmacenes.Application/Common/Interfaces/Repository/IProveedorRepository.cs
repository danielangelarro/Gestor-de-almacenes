using GestorDeAlmacenes.Application.Entities;

namespace GestorDeAlmacenes.Application.Common.Interfaces;

public interface IProveedorRepository
{
  Task<Proveedor> GetProveedorByIdAsync(Guid id);
  Task<IEnumerable<Proveedor>> GetAllProveedoresAsync();
  Task AddProveedorAsync(Proveedor proveedor);
  Task UpdateProveedorAsync(Proveedor proveedor);
  Task DeleteProveedorAsync(Proveedor proveedor);
}
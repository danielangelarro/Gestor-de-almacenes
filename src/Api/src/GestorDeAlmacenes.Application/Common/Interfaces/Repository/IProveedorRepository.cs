using GestorDeAlmacenes.Application.Entities;

namespace GestorDeAlmacenes.Application.Common.Interfaces;

public interface IProveedorRepository
{
  Task<int> GetProveedorCountAsync();
  Task<Proveedor> GetProveedorByIdAsync(Guid? id);
  Task<ICollection<Proveedor>> GetAllProveedoresAsync();
  Task AddProveedorAsync(Proveedor proveedor);
  Task UpdateProveedorAsync(Proveedor proveedor);
  Task DeleteProveedorAsync(Proveedor proveedor);
}
using GestorDeAlmacenes.Application.Entities;

namespace GestorDeAlmacenes.Application.Common.Interfaces;

public interface IUbicacionRepository
{
  Task<Ubicacion> GetUbicacionByIdAsync(Guid id);
  Task<ICollection<Ubicacion>> GetAllUbicacionesAsync();
  Task<ICollection<Ubicacion>> CheckedCaduceDateProductService();
  Task<ICollection<Ubicacion>> GetAllUbicacionesByCasilleroAsync(Guid iD_Casillero);
  Task<ICollection<Ubicacion>> GetAllUbicacionesByProductoAsync(Guid iD_Producto);
  Task AddUbicacionAsync(Ubicacion ubicacion);
  Task UpdateUbicacionAsync(Ubicacion ubicacion);
  Task DeleteUbicacionAsync(Ubicacion ubicacion);
}
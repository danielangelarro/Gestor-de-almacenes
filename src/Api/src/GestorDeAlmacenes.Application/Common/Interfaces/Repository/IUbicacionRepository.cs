using GestorDeAlmacenes.Application.Entities;

namespace GestorDeAlmacenes.Application.Common.Interfaces;

public interface IUbicacionRepository
{
  Task<Ubicacion> GetUbicacionByIdAsync(Guid id);
  Task<IEnumerable<Ubicacion>> GetAllUbicacionesAsync();
  Task<IEnumerable<Ubicacion>> GetAllUbicacionesByCasilleroAsync(Guid iD_Casillero);
  Task<IEnumerable<Ubicacion>> GetAllUbicacionesByProductoAsync(Guid iD_Producto);
  Task AddUbicacionAsync(Ubicacion ubicacion);
  Task UpdateUbicacionAsync(Ubicacion ubicacion);
  Task DeleteUbicacionAsync(Ubicacion ubicacion);
}
using GestorDeAlmacenes.Application.Entities;

namespace GestorDeAlmacenes.Application.Common.Interfaces;

public interface IUbicacionRepository
{
  Task<Ubicacion> GetUbicacionByIdAsync(Guid id);
  Task<IEnumerable<Ubicacion>> GetAllUbicacionesAsync();
  Task AddUbicacionAsync(Ubicacion ubicacion);
  Task UpdateUbicacionAsync(Ubicacion ubicacion);
  Task DeleteUbicacionAsync(Ubicacion ubicacion);
}
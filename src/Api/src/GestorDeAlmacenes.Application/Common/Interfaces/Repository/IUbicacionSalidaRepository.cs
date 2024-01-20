using GestorDeAlmacenes.Application.Entities;

namespace GestorDeAlmacenes.Application.Common.Interfaces;

public interface IUbicacionSalidaRepository
{
  Task<ICollection<Ubicacion_Salida>> GetAllUbicacionesSalidasAsync();
  Task<ICollection<Ubicacion_Salida>> GetAllUbicacionesSalidasBySalidaAsync(Guid salida);
  Task AddUbicacionSalidaAsync(Ubicacion_Salida ubicacion);
  Task DeleteUbicacionsSalidaAsync(Ubicacion_Salida ubicacion);
}
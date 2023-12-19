using GestorDeAlmacenes.Application.Entities;

namespace GestorDeAlmacenes.Application.Common.Interfaces;

public interface ISalidaRepository
{
  Task<Salida> GetSalidaByIdAsync(Guid id);
  Task<ICollection<Salida>> GetAllSalidasAsync();
  Task AddSalidaAsync(Salida salida);
  Task UpdateSalidaAsync(Salida salida);
  Task DeleteSalidaAsync(Salida salida);
}
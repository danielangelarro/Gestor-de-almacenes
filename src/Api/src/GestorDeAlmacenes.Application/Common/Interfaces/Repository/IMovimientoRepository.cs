using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Entities;

namespace GestorDeAlmacenes.Application.Common.Interfaces;

public interface IMovimientoRepository
{
  //!SECTION Entrada
  Task<Movimientos> GetEntradaByIdAsync(Guid id);
  Task<ICollection<Movimientos>> GetAllEntradasAsync();
  Task AddEntradaAsync(Movimientos entrada);
  Task UpdateEntradaAsync(Movimientos entrada);
  Task DeleteEntradaAsync(Movimientos entrada);

  //!SECTION Salida
  Task<Movimientos> GetSalidaByIdAsync(Guid id);
  Task<ICollection<Movimientos>> GetAllSalidasAsync();
  Task AddSalidaAsync(Movimientos salida);
  Task UpdateSalidaAsync(Movimientos salida);
  Task DeleteSalidaAsync(Movimientos salida);

  //!SECTION Merma
  Task<Movimientos> GetMermaByIdAsync(Guid id);
  Task<ICollection<Movimientos>> GetAllMermasAsync();
  Task AddMermaAsync(Movimientos merma);
  Task UpdateMermaAsync(Movimientos merma);
  Task DeleteMermaAsync(Movimientos merma);

  //!SECTION Reportes
  Task<ICollection<Movimientos>> GetAllAsync();
  Task<ICollection<float>> GetAllGananciasMensualAsync();
  Task<ICollection<int>> GetAllEntradasMensualAsync();
  Task<ICollection<int>> GetAllSalidasMensualAsync();
  Task<float> GetGananciaSemanal();
  Task<float> GetGananciaMensual();
  Task<float> GetGananciaLastSemanal();
  Task<float> GetGananciaLastMensual();
  Task<float> GetGananciaAnual();
  Task<int> GetEntradaMensual();
  Task<int> GetEntradaLastMensual();
  Task<int> GetSalidaMensual();
  Task<int> GetSalidaLastMensual();

}
using GestorDeAlmacenes.Application.Entities;

namespace GestorDeAlmacenes.Application.Common.Interfaces;

public interface IEntradaRepository
{
  Task<Entrada> GetEntradaByIdAsync(Guid id);
  Task<IEnumerable<Entrada>> GetAllEntradasAsync();
  Task AddEntradaAsync(Entrada entrada);
  Task UpdateEntradaAsync(Entrada entrada);
  Task DeleteEntradaAsync(Entrada entrada);
}
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Entities;

namespace GestorDeAlmacenes.Application.Common.Interfaces;

public interface IEntradaRepository
{
  Task<Entrada> GetEntradaByIdAsync(Guid id);
  Task<ICollection<ITransaction>> GetAllEntradasAsync();
  Task AddEntradaAsync(Entrada entrada);
  Task UpdateEntradaAsync(Entrada entrada);
  Task DeleteEntradaAsync(Entrada entrada);
}
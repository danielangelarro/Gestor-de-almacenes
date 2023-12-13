using GestorDeAlmacenes.Application.Entities;

namespace GestorDeAlmacenes.Application.Common.Interfaces;

public interface IMermaRepository
{
  Task<Merma> GetMermaByIdAsync(Guid id);
  Task<IEnumerable<Merma>> GetAllMermasAsync();
  Task AddMermaAsync(Merma merma);
  Task UpdateMermaAsync(Merma merma);
  Task DeleteMermaAsync(Merma merma);
}
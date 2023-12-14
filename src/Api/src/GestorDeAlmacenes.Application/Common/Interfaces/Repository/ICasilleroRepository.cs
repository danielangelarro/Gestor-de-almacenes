using GestorDeAlmacenes.Application.Entities;

namespace GestorDeAlmacenes.Application.Common.Interfaces;

public interface ICasilleroRepository
{
  Task<Casillero> GetCasilleroByIdAsync(Guid id);
  Task<IEnumerable<Casillero>> GetAllCasillerosAsync();
  Task<IEnumerable<Casillero>> GetAllCasillerosByIdAsync(ICollection<Guid> guids);
  Task AddCasilleroAsync(Casillero casillero);
  Task UpdateCasilleroAsync(Casillero casillero);
  Task DeleteCasilleroAsync(Casillero casillero);
}
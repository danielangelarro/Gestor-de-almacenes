using GestorDeAlmacenes.Application.Entities;

namespace GestorDeAlmacenes.Application.Common.Interfaces;

public interface ICasilleroRepository
{
  Task<Casillero> GetCasilleroByIdAsync(Guid id);
  Task<ICollection<Casillero>> GetAllCasillerosAsync();
  Task<ICollection<Casillero>> GetAllCasillerosByIdAsync(ICollection<Guid> guids);
  Task AddCasilleroAsync(Casillero casillero);
  Task UpdateCasilleroAsync(Casillero casillero);
  Task DeleteCasilleroAsync(Casillero casillero);
}
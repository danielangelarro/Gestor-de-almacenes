using GestorDeAlmacenes.Application.Entities;

namespace GestorDeAlmacenes.Application.Common.Interfaces;

public interface IRackRepository
{
  Task<Rack> GetRackByIdAsync(Guid id);
  Task<ICollection<Rack>> GetAllRacksAsync();
  Task AddRackAsync(Rack rack);
  Task UpdateRackAsync(Rack rack);
  Task DeleteRackAsync(Rack rack);
}
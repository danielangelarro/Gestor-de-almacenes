using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Entities;

namespace GestorDeAlmacenes.Application.Common.Interfaces;

public interface INotificacionRepository
{
  Task<Notificacion> GetNotificacionByIdAsync(Guid id);
  Task<ICollection<Notificacion>> GetAllNotificacionesByUserAsync(Guid ID_Usuario);
  Task AddNotificacionAsync(Notificacion entrada);
  Task AddDiffusionNotificacionAsync(string Mensaje, string Tipo, DateTime Fecha);
  Task DeleteNotificacionAsync(Notificacion entrada);
}
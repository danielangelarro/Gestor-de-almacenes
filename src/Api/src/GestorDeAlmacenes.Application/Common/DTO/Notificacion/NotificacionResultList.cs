using GestorDeAlmacenes.Application.Entities;

namespace GestorDeAlmacenes.Application.DTO.Notificaciones
{
    public record NotificacionResultList(ICollection<Notificacion> notificacions);
}
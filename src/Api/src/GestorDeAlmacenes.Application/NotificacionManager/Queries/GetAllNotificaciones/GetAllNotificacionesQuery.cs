using ErrorOr;
using GestorDeAlmacenes.Application.DTO.Notificaciones;
using MediatR;

namespace GestorDeAlmacenes.Application.Notificaciones.Query.GetAllNotificaciones;

public record GetAllNotificacionesQuery(string Token) : IRequest<ErrorOr<NotificacionResultList>>;

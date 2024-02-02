using MediatR;
using ErrorOr;
using GestorDeAlmacenes.Application.DTO.Notificaciones;

namespace GestorDeAlmacenes.Application.Notificaciones.Commands.Delete;

public record DeleteNotificacionCommands(Guid ID_Notificacion) : IRequest<ErrorOr<NotificacionResult>>;


using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;
using ErrorOr;
using GestorDeAlmacenes.Application.DTO.Notificaciones;

namespace GestorDeAlmacenes.Application.Notificaciones.Commands.Delete;

public class DeleteNotificacionCommandsHandler : IRequestHandler<DeleteNotificacionCommands, ErrorOr<NotificacionResult>>
{
    private readonly INotificacionRepository _notificacionRepository;

    public DeleteNotificacionCommandsHandler(INotificacionRepository notificacionRepository)
    {
        _notificacionRepository = notificacionRepository;
    }

    public async Task<ErrorOr<NotificacionResult>> Handle(DeleteNotificacionCommands command, CancellationToken cancellationToken)
    {
        if (await _notificacionRepository.GetNotificacionByIdAsync(command.ID_Notificacion) is not Notificacion notificacion)
        {
            return Errors.Notificacion.NotificacionNotFound;
        }

        await _notificacionRepository.DeleteNotificacionAsync(notificacion);

        return new NotificacionResult(notificacion);
    }
}

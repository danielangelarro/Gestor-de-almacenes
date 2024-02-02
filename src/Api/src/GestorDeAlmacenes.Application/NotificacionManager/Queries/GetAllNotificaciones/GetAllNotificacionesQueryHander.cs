using ErrorOr;
using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Notificaciones;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Application.Services;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;

namespace GestorDeAlmacenes.Application.Notificaciones.Query.GetAllNotificaciones;

public class GetAllNotificacionesQueryHandler : IRequestHandler<GetAllNotificacionesQuery, ErrorOr<NotificacionResultList>>
{
    private readonly INotificacionRepository _notificacionRepository;
    private readonly IGetCurrentUserLoginService _getCurrentUserLoginService;

    public GetAllNotificacionesQueryHandler(INotificacionRepository notificacionRepository, IGetCurrentUserLoginService getCurrentUserLoginService)
    {
        _notificacionRepository = notificacionRepository;
        _getCurrentUserLoginService = getCurrentUserLoginService;
    }

    public async Task<ErrorOr<NotificacionResultList>> Handle(GetAllNotificacionesQuery query, CancellationToken cancellationToken)
    {
        if (await _getCurrentUserLoginService.Handle(query.Token) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        return new NotificacionResultList(await _notificacionRepository.GetAllNotificacionesByUserAsync(user.ID_User));
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using MediatR;
using ErrorOr;
using GestorDeAlmacenes.Application.Notificaciones.Commands.Delete;
using GestorDeAlmacenes.Application.DTO.Notificaciones;
using GestorDeAlmacenes.Application.Notificaciones.Query.GetAllNotificaciones;

namespace GestorDeAlmacenes.API.Controllers;

[Authorize]
[Route("notificacion")]
public class NotificacionController : ApiController
{
    private readonly ISender _mediator;

    public NotificacionController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> GetAllNotificacionsByUser(NotificacionUpload notificacion)
    {
        var query = new GetAllNotificacionesQuery(notificacion.Token);

        ErrorOr<NotificacionResultList> notificacionResultList = await _mediator.Send(query);
        
        return notificacionResultList.Match(
            result => Ok(notificacionResultList),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{notificacionId}")]
    public async Task<IActionResult> DeleteNotificacion(Guid notificacionId)
    {
        var query = new DeleteNotificacionCommands(notificacionId);

        ErrorOr<NotificacionResult> notificacionResult = await _mediator.Send(query);
        
        return notificacionResult.Match(
            result => Ok(),
            errors => Problem(errors)
        );
    }
}
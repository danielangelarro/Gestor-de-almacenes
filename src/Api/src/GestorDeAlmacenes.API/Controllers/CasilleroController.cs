using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using MediatR;
using ErrorOr;
using GestorDeAlmacenes.Application.Casilleros.Query.GetAllCasilleros;
using GestorDeAlmacenes.Application.DTO.Casilleros;
using GestorDeAlmacenes.Application.Casilleros.Query.GetCasilleroById;
using GestorDeAlmacenes.Application.Casilleros.Commands.Delete;
using GestorDeAlmacenes.Application.Casilleros.Commands.Update;
using GestorDeAlmacenes.Application.Casilleros.Commands.Add;
using GestorDeAlmacenes.Application.Casilleros.Query.GetCasilleroByRackId;
using GestorDeAlmacenes.Application.Common.DTO.Casillero;
using GestorDeAlmacenes.Application.Casilleros.Query.GetCasilleroWait;


namespace GestorDeAlmacenes.API.Controllers;

[Authorize]
[Route("casillero")]
public class CasilleroController : ApiController
{
    private readonly ISender _mediator;

    public CasilleroController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetCasilleros()
    {
        var query = new GetAllCasillerosQuery();

        ErrorOr<CasilleroResultList> casilleroResultList = await _mediator.Send(query);
        
        return casilleroResultList.Match(
            result => Ok(casilleroResultList),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCasilleroById(Guid id)
    {
        var query = new GetCasilleroByIdQuery(id);

        ErrorOr<CasilleroResultInfo> casilleroResult = await _mediator.Send(query);
        
        return casilleroResult.Match(
            result => Ok(casilleroResult),
            errors => Problem(errors)
        );
    }
    
    [HttpGet("rack/{rackId}")]
    public async Task<IActionResult> GetCasilleroByRack(Guid rackId)
    {
        var query = new GetCasilleroByIdRackQuery(rackId);

        ErrorOr<CasilleroResultList> casilleroResultList = await _mediator.Send(query);
        
        return casilleroResultList.Match(
            result => Ok(casilleroResultList),
            errors => Problem(errors)
        );
    }
    
    [HttpGet("wait/")]
    public async Task<IActionResult> GetCasilleroWait()
    {
        var query = new GetCasilleroWaitQuery();

        ErrorOr<CasilleroResult> casilleroResult = await _mediator.Send(query);
        
        return casilleroResult.Match(
            result => Ok(casilleroResult),
            errors => Problem(errors)
        );
    }
    
    [HttpPost]
    public async Task<IActionResult> GetAllCasilleroByRack(CasilleroUploadListRequest list_rackId)
    {
        var query = new GetAllCasillerosByIdQuery(list_rackId.Guids);

        ErrorOr<CasilleroResultList> casilleroResultList = await _mediator.Send(query);
        
        return casilleroResultList.Match(
            result => Ok(casilleroResultList),
            errors => Problem(errors)
        );
    }
    
    [HttpPost("add")]
    public async Task<IActionResult> AddCasillero(CasilleroUploadRequest request)
    {
        var query = new AddCasilleroCommands(
            request.ID_Rack,
            -1,
            request.Area,
            request.Peso_Maximo,
            request.Alto,
            request.Ancho,
            request.Largo,
            request.Unidad_Dimensiones
        );

        ErrorOr<CasilleroResult> casilleroResult = await _mediator.Send(query);
        
        return casilleroResult.Match(
            result => Ok(casilleroResult),
            errors => Problem(errors)
        );
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateCasillero(CasilleroUpdateRequest request)
    {
        var query = new UpdateCasilleroCommands(
            request.ID_Casillero,
            request.Area,
            request.Peso_Maximo,
            request.Alto,
            request.Ancho,
            request.Largo,
            request.Unidad_Dimensiones
        );

        ErrorOr<CasilleroResult> casilleroResult = await _mediator.Send(query);
        
        return casilleroResult.Match(
            result => Ok(casilleroResult),
            errors => Problem(errors)
        );
    }
    
    [HttpDelete("{casilleroId}")]
    public async Task<IActionResult> DeleteCasillero(Guid casilleroId)
    {
        var query = new DeleteCasilleroCommands(casilleroId);

        ErrorOr<CasilleroResult> casilleroResult = await _mediator.Send(query);
        
        return casilleroResult.Match(
            result => Ok(),
            errors => Problem(errors)
        );
    }
}
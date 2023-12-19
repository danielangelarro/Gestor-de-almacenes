using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using MediatR;
using ErrorOr;
using GestorDeAlmacenes.Application.DTO.EntradaAndSalidas;
using GestorDeAlmacenes.Application.EntradaAndSalidas.Query.GetEntradaAndSalidaById;
using GestorDeAlmacenes.Application.Entradas.Commands.Add;
using GestorDeAlmacenes.Application.Salidas.Commands.Add;
using GestorDeAlmacenes.Application.Entradas.Query.GetAllEntradas;
using GestorDeAlmacenes.Application.DTO.Entradas;
using GestorDeAlmacenes.Application.Salidas.Query.GetAllSalidas;
using GestorDeAlmacenes.Application.DTO.Salidas;
using GestorDeAlmacenes.Application.Entradas.Query.GetEntradaById;
using GestorDeAlmacenes.Application.Salidas.Query.GetSalidaById;


namespace GestorDeAlmacenes.API.Controllers;

[Authorize]
[Route("entradaandsalida")]
public class EntradaAndSalidaController : ApiController
{
    private readonly ISender _mediator;

    public EntradaAndSalidaController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetEntradas()
    {
        var query = new GetAllEntradasQuery();

        ErrorOr<EntradaResultList> entradasResultList = await _mediator.Send(query);
        
        return entradasResultList.Match(
            result => Ok(entradasResultList),
            errors => Problem(errors)
        );
    }
    
    [HttpGet]
    public async Task<IActionResult> GetSalidas()
    {
        var query = new GetAllSalidasQuery();

        ErrorOr<SalidaResultList> salidasResultList = await _mediator.Send(query);
        
        return salidasResultList.Match(
            result => Ok(salidasResultList),
            errors => Problem(errors)
        );
    }
    
    [HttpGet]
    public async Task<IActionResult> GetEntradaAndSalidas()
    {
        var query = new GetAllEntradaAndSalidasQuery();

        ErrorOr<EntradaAndSalidaResultList> entradaAndSalidaResultList = await _mediator.Send(query);
        
        return entradaAndSalidaResultList.Match(
            result => Ok(entradaAndSalidaResultList),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEntradaById(Guid id)
    {
        var query = new GetEntradaByIdQuery(id);

        ErrorOr<EntradaResult> entradaResult = await _mediator.Send(query);
        
        return entradaResult.Match(
            result => Ok(entradaResult),
            errors => Problem(errors)
        );
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSalidaById(Guid id)
    {
        var query = new GetSalidaByIdQuery(id);

        ErrorOr<SalidaResult> salidaResult = await _mediator.Send(query);
        
        return salidaResult.Match(
            result => Ok(salidaResult),
            errors => Problem(errors)
        );
    }
    
    [HttpPost]
    public async Task<IActionResult> AddEntrada(UploadEntradaRequest request)
    {
        var query = new AddEntradaCommands(
            request.ID_Producto,
            request.ID_Usuario,
            request.Cantidad,
            request.Fecha
        );

        ErrorOr<EntradaResult> entradaResult = await _mediator.Send(query);
        
        return entradaResult.Match(
            result => Ok(entradaResult),
            errors => Problem(errors)
        );
    }
    
    [HttpPost]
    public async Task<IActionResult> AddSalida(UploadEntradaRequest request)
    {
        var query = new AddSalidaCommands(
            request.ID_Producto,
            request.ID_Usuario,
            request.Cantidad,
            request.Fecha
        );

        ErrorOr<SalidaResult> salidaResult = await _mediator.Send(query);
        
        return salidaResult.Match(
            result => Ok(salidaResult),
            errors => Problem(errors)
        );
    }
}
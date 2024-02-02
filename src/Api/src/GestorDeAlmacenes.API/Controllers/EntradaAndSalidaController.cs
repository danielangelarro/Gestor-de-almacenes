using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using MediatR;
using Aspose.Pdf;
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
using GestorDeAlmacenes.Application.Entradas.Query.GetAllEntradaReport;
using GestorDeAlmacenes.Application.Entradas.Query.GetAllSalidaReport;


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

    [HttpGet("entrada")]
    public async Task<IActionResult> GetEntradas()
    {
        var query = new GetAllEntradasQuery();

        ErrorOr<EntradaResultList> entradasResultList = await _mediator.Send(query);
        
        return entradasResultList.Match(
            result => Ok(entradasResultList),
            errors => Problem(errors)
        );
    }

    [HttpGet("entrada/report")]
    public async Task<IActionResult> GetEntradaReport()
    {
        var query = new GetAllEntradasReportQuery();
        ErrorOr<Document> document = await _mediator.Send(query);

        using (MemoryStream stream = new MemoryStream())
        {
            document.Value.Save(stream);
            return File(stream.ToArray(), "application/pdf", "ReporteEntradaProductos.pdf");
        }
    }
    
    [HttpGet("salida/report")]
    public async Task<IActionResult> GetSalidaReport()
    {
        var query = new GetAllSalidasReportQuery();
        ErrorOr<Document> document = await _mediator.Send(query);

        using (MemoryStream stream = new MemoryStream())
        {
            document.Value.Save(stream);
            return File(stream.ToArray(), "application/pdf", "ReporteSalidaProductos.pdf");
        }
    }
    
    [HttpGet("salida")]
    public async Task<IActionResult> GetSalidas()
    {
        var query = new GetAllSalidasQuery();

        ErrorOr<SalidaResultList> salidasResultList = await _mediator.Send(query);
        
        return salidasResultList.Match(
            result => Ok(salidasResultList),
            errors => Problem(errors)
        );
    }
    
    [HttpGet("history")]
    public async Task<IActionResult> GetEntradaAndSalidas()
    {
        var query = new GetAllEntradaAndSalidasQuery();

        ErrorOr<EntradaAndSalidaResultList> entradaAndSalidaResultList = await _mediator.Send(query);
        
        return entradaAndSalidaResultList.Match(
            result => Ok(entradaAndSalidaResultList),
            errors => Problem(errors)
        );
    }

    [HttpGet("entrada/{id}")]
    public async Task<IActionResult> GetEntradaById(Guid id)
    {
        var query = new GetEntradaByIdQuery(id);

        ErrorOr<EntradaResult> entradaResult = await _mediator.Send(query);
        
        return entradaResult.Match(
            result => Ok(entradaResult),
            errors => Problem(errors)
        );
    }
    
    [HttpGet("salida/{id}")]
    public async Task<IActionResult> GetSalidaById(Guid id)
    {
        var query = new GetSalidaByIdQuery(id);

        ErrorOr<SalidaResult> salidaResult = await _mediator.Send(query);
        
        return salidaResult.Match(
            result => Ok(salidaResult),
            errors => Problem(errors)
        );
    }
    
    [HttpPost("entrada/add")]
    public async Task<IActionResult> AddEntrada(UploadEntradaRequest request)
    {
        var query = new AddEntradaCommands(
            request.ID_Producto,
            request.ID_Usuario,
            request.Cantidad,
            request.Precio_Unidad,
            request.Fecha,
            request.Fecha_Caducidad,
            request.Token
        );

        ErrorOr<EntradaResult> entradaResult = await _mediator.Send(query);
        
        return entradaResult.Match(
            result => Ok(entradaResult),
            errors => Problem(errors)
        );
    }
    
    [HttpPost("salida/add")]
    public async Task<IActionResult> AddSalida(UploadSalidaRequest request)
    {
        var query = new AddSalidaCommands(
            request.ID_Producto,
            request.ID_Usuario,
            request.Cantidad,
            request.Precio_Unidad,
            request.Fecha,
            request.Token
        );

        ErrorOr<SalidaResult> salidaResult = await _mediator.Send(query);
        
        return salidaResult.Match(
            result => Ok(salidaResult),
            errors => Problem(errors)
        );
    }
}
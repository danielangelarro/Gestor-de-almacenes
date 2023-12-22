using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using MediatR;
using ErrorOr;
using GestorDeAlmacenes.Application.Mermas.Query.GetAllMermas;
using GestorDeAlmacenes.Application.DTO.Mermas;
using GestorDeAlmacenes.Application.Mermas.Query.GetMermaById;
using GestorDeAlmacenes.Application.Mermas.Commands.Add;


namespace GestorDeAlmacenes.API.Controllers;

[Authorize]
[Route("merma")]
public class MermaController : ApiController
{
    private readonly ISender _mediator;

    public MermaController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetMermas()
    {
        var query = new GetAllMermasQuery();

        ErrorOr<MermaResultList> mermaResultList = await _mediator.Send(query);
        
        return mermaResultList.Match(
            result => Ok(mermaResultList),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMermaById(Guid id)
    {
        var query = new GetMermaByIdQuery(id);

        ErrorOr<MermaResult> mermaResult = await _mediator.Send(query);
        
        return mermaResult.Match(
            result => Ok(mermaResult),
            errors => Problem(errors)
        );
    }
    
    [HttpPost]
    public async Task<IActionResult> AddMerma(MermaUploadRequest request)
    {
        var query = new AddMermaCommands(
            request.ID_Merma,
            request.ID_Producto,
            request.Cantidad,
            request.Fecha_Caducidad
        );

        ErrorOr<MermaResult> mermaResult = await _mediator.Send(query);
        
        return mermaResult.Match(
            result => Ok(mermaResult),
            errors => Problem(errors)
        );
    }
}
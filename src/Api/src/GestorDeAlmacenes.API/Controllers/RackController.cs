using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using MediatR;
using ErrorOr;
using GestorDeAlmacenes.Application.Racks.Query.GetAllRacks;
using GestorDeAlmacenes.Application.DTO.Racks;
using GestorDeAlmacenes.Application.Racks.Query.GetRackById;
using GestorDeAlmacenes.Application.Racks.Commands.Delete;
using GestorDeAlmacenes.Application.Racks.Commands.Update;
using GestorDeAlmacenes.Application.Racks.Commands.Add;


namespace GestorDeAlmacenes.API.Controllers;

[Authorize]
[Route("rack")]
public class RackController : ApiController
{
    private readonly ISender _mediator;

    public RackController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetRacks()
    {
        var query = new GetAllRacksQuery();

        ErrorOr<RackResultList> rackResultList = await _mediator.Send(query);
        
        return rackResultList.Match(
            result => Ok(rackResultList),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRackById(Guid id)
    {
        var query = new GetRackByIdQuery(id);

        ErrorOr<RackResult> rackResult = await _mediator.Send(query);
        
        return rackResult.Match(
            result => Ok(rackResult),
            errors => Problem(errors)
        );
    }
    
    
    [HttpPost]
    public async Task<IActionResult> AddRack(RackUploadRequest request)
    {
        var query = new AddRackCommands(
            request.Pasillo
        );

        ErrorOr<RackResult> rackResult = await _mediator.Send(query);
        
        return rackResult.Match(
            result => Ok(rackResult),
            errors => Problem(errors)
        );
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateRack(RackUpdateRequest request)
    {
        var query = new UpdateRackCommands(
            request.ID_Rack,
            request.Pasillo
        );

        ErrorOr<RackResult> rackResult = await _mediator.Send(query);
        
        return rackResult.Match(
            result => Ok(rackResult),
            errors => Problem(errors)
        );
    }
    
    [HttpDelete("{rackId}")]
    public async Task<IActionResult> DeleteRack(Guid rackId)
    {
        var query = new DeleteRackCommands(rackId);

        ErrorOr<RackResult> rackResult = await _mediator.Send(query);
        
        return rackResult.Match(
            result => Ok(),
            errors => Problem(errors)
        );
    }
}
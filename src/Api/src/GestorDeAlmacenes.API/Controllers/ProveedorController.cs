using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using MediatR;
using ErrorOr;
using GestorDeAlmacenes.Application.Proveedors.Query.GetAllProveedors;
using GestorDeAlmacenes.Application.DTO.Proveedors;
using GestorDeAlmacenes.Application.Proveedors.Query.GetProveedorById;
using GestorDeAlmacenes.Application.Proveedors.Commands.Delete;
using GestorDeAlmacenes.Application.Proveedors.Commands.Update;
using GestorDeAlmacenes.Application.Proveedors.Commands.Add;


namespace GestorDeAlmacenes.API.Controllers;

[Authorize]
[Route("proveedor")]
public class ProveedorController : ApiController
{
    private readonly ISender _mediator;

    public ProveedorController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetProveedors()
    {
        var query = new GetAllProveedorsQuery();

        ErrorOr<ProveedorResultList> proveedorResultList = await _mediator.Send(query);
        
        return proveedorResultList.Match(
            result => Ok(proveedorResultList),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProveedorById(Guid id)
    {
        var query = new GetProveedorByIdQuery(id);

        ErrorOr<ProveedorResult> proveedorResult = await _mediator.Send(query);
        
        return proveedorResult.Match(
            result => Ok(proveedorResult),
            errors => Problem(errors)
        );
    }
    
    
    [HttpPost]
    public async Task<IActionResult> AddProveedor(ProveedorUploadRequest request)
    {
        var query = new AddProveedorCommands(
            request.Nombres,
            request.Apellidos,
            request.CI,
            request.Telefono,
            request.Correo,
            request.Direccion
        );

        ErrorOr<ProveedorResult> proveedorResult = await _mediator.Send(query);
        
        return proveedorResult.Match(
            result => Ok(proveedorResult),
            errors => Problem(errors)
        );
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateProveedor(ProveedorUpdateRequest request)
    {
        var query = new UpdateProveedorCommands(
            request.ID_Proveedor,
            request.Nombres,
            request.Apellidos,
            request.CI,
            request.Telefono,
            request.Correo,
            request.Direccion
        );

        ErrorOr<ProveedorResult> proveedorResult = await _mediator.Send(query);
        
        return proveedorResult.Match(
            result => Ok(proveedorResult),
            errors => Problem(errors)
        );
    }
    
    [HttpDelete("{proveedorId}")]
    public async Task<IActionResult> DeleteProveedor(Guid proveedorId)
    {
        var query = new DeleteProveedorCommands(proveedorId);

        ErrorOr<ProveedorResult> proveedorResult = await _mediator.Send(query);
        
        return proveedorResult.Match(
            result => Ok(),
            errors => Problem(errors)
        );
    }
}
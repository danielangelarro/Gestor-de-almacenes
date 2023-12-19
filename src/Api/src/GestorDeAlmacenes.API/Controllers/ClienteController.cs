using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using MediatR;
using ErrorOr;
using GestorDeAlmacenes.Application.Clientes.Query.GetAllClientes;
using GestorDeAlmacenes.Application.DTO.Clientes;
using GestorDeAlmacenes.Application.Clientes.Query.GetClienteById;
using GestorDeAlmacenes.Application.Clientes.Commands.Delete;
using GestorDeAlmacenes.Application.Clientes.Commands.Update;
using GestorDeAlmacenes.Application.Clientes.Commands.Add;


namespace GestorDeAlmacenes.API.Controllers;

[Authorize]
[Route("cliente")]
public class ClienteController : ApiController
{
    private readonly ISender _mediator;

    public ClienteController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetClientes()
    {
        var query = new GetAllClientesQuery();

        ErrorOr<ClienteResultList> clienteResultList = await _mediator.Send(query);
        
        return clienteResultList.Match(
            result => Ok(clienteResultList),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetClienteById(Guid id)
    {
        var query = new GetClienteByIdQuery(id);

        ErrorOr<ClienteResult> clienteResult = await _mediator.Send(query);
        
        return clienteResult.Match(
            result => Ok(clienteResult),
            errors => Problem(errors)
        );
    }
    
    [HttpPost]
    public async Task<IActionResult> AddCliente(ClienteUploadRequest request)
    {
        var query = new AddClienteCommands(
            request.Nombres,
            request.Apellidos,
            request.CI,
            request.Telefono,
            request.Correo,
            request.Direccion
        );

        ErrorOr<ClienteResult> clienteResult = await _mediator.Send(query);
        
        return clienteResult.Match(
            result => Ok(clienteResult),
            errors => Problem(errors)
        );
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateCliente(ClienteUpdateRequest request)
    {
        var query = new UpdateClienteCommands(
            request.ID_Cliente,
            request.Nombres,
            request.Apellidos,
            request.CI,
            request.Telefono,
            request.Correo,
            request.Direccion
        );

        ErrorOr<ClienteResult> clienteResult = await _mediator.Send(query);
        
        return clienteResult.Match(
            result => Ok(clienteResult),
            errors => Problem(errors)
        );
    }
    
    [HttpDelete("{clienteId}")]
    public async Task<IActionResult> DeleteCliente(Guid clienteId)
    {
        var query = new DeleteClienteCommands(clienteId);

        ErrorOr<ClienteResult> clienteResult = await _mediator.Send(query);
        
        return clienteResult.Match(
            result => Ok(),
            errors => Problem(errors)
        );
    }
}
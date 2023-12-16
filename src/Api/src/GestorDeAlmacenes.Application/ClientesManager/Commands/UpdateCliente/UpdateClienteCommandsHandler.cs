using System.Net.Http.Headers;
using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Clientes;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Clientes.Commands.Update;

public class UpdateClienteCommandsHandler : IRequestHandler<UpdateClienteCommands, ErrorOr<ClienteResult>>
{
   private readonly IClienteRepository _clienteRepository;

   public UpdateClienteCommandsHandler(IClienteRepository clienteRepository)
   {
       _clienteRepository = clienteRepository;
   }

   public async Task<ErrorOr<ClienteResult>> Handle(UpdateClienteCommands command, CancellationToken cancellationToken)
   {
        if (await _clienteRepository.GetClienteByIdAsync(command.Id) is not Cliente cliente)
        {
            return Errors.Cliente.NotFound;
        }

        cliente.Nombres = command.Nombres;
        cliente.Apellidos = command.Apellidos;
        cliente.CI = command.CI;
        cliente.Telefono = command.Telefono;
        cliente.Correo = command.Correo;
        cliente.Direccion = command.Direccion;

       await _clienteRepository.UpdateClienteAsync(cliente);
       
       return new ClienteResult(cliente);
   }
}

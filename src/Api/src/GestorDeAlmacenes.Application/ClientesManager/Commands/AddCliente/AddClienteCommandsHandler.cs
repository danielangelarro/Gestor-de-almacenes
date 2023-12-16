using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Clientes;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Clientes.Commands.Add;

public class AddClienteCommandsHandler : IRequestHandler<AddClienteCommands, ErrorOr<ClienteResult>>
{
   private readonly IClienteRepository _clienteRepository;

   public AddClienteCommandsHandler(IClienteRepository clienteRepository)
   {
       _clienteRepository = clienteRepository;
   }

   public async Task<ErrorOr<ClienteResult>> Handle(AddClienteCommands command, CancellationToken cancellationToken)
   {
       var cliente = new Cliente
       {
            ID_Cliente = Guid.NewGuid(),
            Nombres = command.Nombres,
            Apellidos = command.Apellidos,
            CI = command.CI,
            Telefono = command.Telefono,
            Correo = command.Correo,
            Direccion = command.Direccion
       };

       await _clienteRepository.AddClienteAsync(cliente);
       
       return new ClienteResult(cliente);
   }
}

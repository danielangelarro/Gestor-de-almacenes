using System.Net.Http.Headers;
using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Clientes;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Clientes.Commands.Delete;

public class DeleteClienteCommandsHandler : IRequestHandler<DeleteClienteCommands, ErrorOr<ClienteResult>>
{
   private readonly IClienteRepository _clienteRepository;

   public DeleteClienteCommandsHandler(IClienteRepository clienteRepository)
   {
       _clienteRepository = clienteRepository;
   }

   public async Task<ErrorOr<ClienteResult>> Handle(DeleteClienteCommands command, CancellationToken cancellationToken)
   {
        if (await _clienteRepository.GetClienteByIdAsync(command.Id) is not Cliente cliente)
        {
            return Errors.Cliente.NotFound;
        }

       await _clienteRepository.DeleteClienteAsync(cliente);
       
       return new ClienteResult(cliente);
   }
}

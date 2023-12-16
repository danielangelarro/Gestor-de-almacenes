using GestorDeAlmacenes.Application.DTO.Clientes;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Clientes.Commands.Delete;

public record DeleteClienteCommands(
   Guid Id
) : IRequest<ErrorOr<ClienteResult>>;


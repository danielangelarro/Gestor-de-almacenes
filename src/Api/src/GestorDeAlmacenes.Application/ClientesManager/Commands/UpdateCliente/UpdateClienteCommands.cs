using GestorDeAlmacenes.Application.DTO.Clientes;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Clientes.Commands.Update;

public record UpdateClienteCommands(
   Guid Id,
   string Nombres,
   string Apellidos,
   string CI,
   string Telefono,
   string Correo,
   string Direccion
) : IRequest<ErrorOr<ClienteResult>>;

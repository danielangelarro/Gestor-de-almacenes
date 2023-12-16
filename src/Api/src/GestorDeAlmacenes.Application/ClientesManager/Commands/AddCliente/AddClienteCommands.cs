using MediatR;
using ErrorOr;
using GestorDeAlmacenes.Application.DTO.Clientes;

namespace GestorDeAlmacenes.Application.Clientes.Commands.Add;

public record AddClienteCommands(
   string Nombres,
   string Apellidos,
   string CI,
   string Telefono,
   string Correo,
   string Direccion
) : IRequest<ErrorOr<ClienteResult>>;


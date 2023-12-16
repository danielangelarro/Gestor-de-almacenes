using GestorDeAlmacenes.Application.DTO.Proveedors;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Proveedors.Commands.Update;

public record UpdateProveedorCommands(
   Guid Id,
   string Nombres,
   string Apellidos,
   string CI,
   string Telefono,
   string Correo,
   string Direccion
) : IRequest<ErrorOr<ProveedorResult>>;

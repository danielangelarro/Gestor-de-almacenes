using MediatR;
using ErrorOr;
using GestorDeAlmacenes.Application.DTO.Proveedors;

namespace GestorDeAlmacenes.Application.Proveedors.Commands.Add;

public record AddProveedorCommands(
   string Nombres,
   string Apellidos,
   string CI,
   string Telefono,
   string Correo,
   string Direccion
) : IRequest<ErrorOr<ProveedorResult>>;


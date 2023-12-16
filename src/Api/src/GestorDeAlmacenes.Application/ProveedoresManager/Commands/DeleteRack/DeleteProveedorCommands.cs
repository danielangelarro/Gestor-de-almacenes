using GestorDeAlmacenes.Application.DTO.Proveedors;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Proveedors.Commands.Delete;

public record DeleteProveedorCommands(
   Guid Id
) : IRequest<ErrorOr<ProveedorResult>>;


using ErrorOr;
using GestorDeAlmacenes.Application.DTO.Proveedors;
using MediatR;

namespace GestorDeAlmacenes.Application.Proveedors.Query.GetProveedorById;

public record GetProveedorByIdQuery(
    Guid Id
) : IRequest<ErrorOr<ProveedorResult>>;
using ErrorOr;
using GestorDeAlmacenes.Application.DTO.Proveedors;
using MediatR;

namespace GestorDeAlmacenes.Application.Proveedors.Query.GetAllProveedors;

public record GetAllProveedorsQuery() : IRequest<ErrorOr<ProveedorResultList>>;

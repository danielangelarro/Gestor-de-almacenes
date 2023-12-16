using ErrorOr;
using GestorDeAlmacenes.Application.DTO.Racks;
using MediatR;

namespace GestorDeAlmacenes.Application.Racks.Query.GetRackById;

public record GetRackByIdQuery(
    Guid Id
) : IRequest<ErrorOr<RackResult>>;
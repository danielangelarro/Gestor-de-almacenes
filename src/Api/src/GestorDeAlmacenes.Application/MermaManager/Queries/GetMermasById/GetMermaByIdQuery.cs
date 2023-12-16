using ErrorOr;
using GestorDeAlmacenes.Application.DTO.Mermas;
using MediatR;

namespace GestorDeAlmacenes.Application.Mermas.Query.GetMermaById;

public record GetMermaByIdQuery(
    Guid Id
) : IRequest<ErrorOr<MermaResult>>;
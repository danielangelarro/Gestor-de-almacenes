using ErrorOr;
using GestorDeAlmacenes.Application.DTO.Mermas;
using MediatR;

namespace GestorDeAlmacenes.Application.Mermas.Query.GetAllMermas;

public record GetAllMermasQuery() : IRequest<ErrorOr<MermaResultList>>;

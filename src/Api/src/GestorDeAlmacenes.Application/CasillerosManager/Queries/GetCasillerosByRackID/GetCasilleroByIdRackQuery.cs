using ErrorOr;
using GestorDeAlmacenes.Application.DTO.Casilleros;
using MediatR;

namespace GestorDeAlmacenes.Application.Casilleros.Query.GetCasilleroByRackId;

public record GetCasilleroByIdRackQuery(
    Guid ID_Rack
) : IRequest<ErrorOr<CasilleroResultList>>;
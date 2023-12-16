using ErrorOr;
using GestorDeAlmacenes.Application.DTO.Casilleros;
using MediatR;

namespace GestorDeAlmacenes.Application.Casilleros.Query.GetAllCasilleros;

public record GetAllCasillerosByIdQuery(
    List<Guid> Guids
) : IRequest<ErrorOr<CasilleroResultList>>;

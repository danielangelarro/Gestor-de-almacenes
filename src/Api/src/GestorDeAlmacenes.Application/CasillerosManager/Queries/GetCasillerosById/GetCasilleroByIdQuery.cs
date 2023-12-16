using ErrorOr;
using GestorDeAlmacenes.Application.DTO.Casilleros;
using MediatR;

namespace GestorDeAlmacenes.Application.Casilleros.Query.GetCasilleroById;

public record GetCasilleroByIdQuery(
    Guid Id
) : IRequest<ErrorOr<CasilleroResult>>;
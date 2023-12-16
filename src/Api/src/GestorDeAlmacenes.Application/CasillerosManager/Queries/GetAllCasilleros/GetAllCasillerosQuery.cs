using ErrorOr;
using GestorDeAlmacenes.Application.DTO.Casilleros;
using MediatR;

namespace GestorDeAlmacenes.Application.Casilleros.Query.GetAllCasilleros;

public record GetAllCasillerosQuery() : IRequest<ErrorOr<CasilleroResultList>>;

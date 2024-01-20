using ErrorOr;
using GestorDeAlmacenes.Application.DTO.Casilleros;
using MediatR;

namespace GestorDeAlmacenes.Application.Casilleros.Query.GetCasilleroWait;

public record GetCasilleroWaitQuery() : IRequest<ErrorOr<CasilleroResult>>;
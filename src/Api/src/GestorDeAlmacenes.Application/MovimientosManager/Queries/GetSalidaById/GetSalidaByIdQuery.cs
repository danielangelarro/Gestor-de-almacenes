using ErrorOr;
using GestorDeAlmacenes.Application.DTO.Salidas;
using MediatR;

namespace GestorDeAlmacenes.Application.Salidas.Query.GetSalidaById;

public record GetSalidaByIdQuery(
    Guid Id
) : IRequest<ErrorOr<SalidaResult>>;
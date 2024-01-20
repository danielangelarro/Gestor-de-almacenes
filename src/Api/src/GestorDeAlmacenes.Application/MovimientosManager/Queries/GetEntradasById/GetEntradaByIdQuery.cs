using ErrorOr;
using GestorDeAlmacenes.Application.DTO.Entradas;
using MediatR;

namespace GestorDeAlmacenes.Application.Entradas.Query.GetEntradaById;

public record GetEntradaByIdQuery(
    Guid Id
) : IRequest<ErrorOr<EntradaResult>>;
using ErrorOr;
using GestorDeAlmacenes.Application.DTO.EntradaAndSalidas;
using MediatR;

namespace GestorDeAlmacenes.Application.EntradaAndSalidas.Query.GetEntradaAndSalidaById;

public record GetAllEntradaAndSalidasQuery(
) : IRequest<ErrorOr<EntradaAndSalidaResultList>>;
using ErrorOr;
using GestorDeAlmacenes.Application.DTO.EntradaAndSalidas;
using MediatR;

namespace GestorDeAlmacenes.Application.EntradaAndSalidas.Query.GetEntradaAndSalidaById;

public record GetAllEntradaAndSalidasQuery(
    Guid ID_Entrada,
    Guid ID_Salida
) : IRequest<ErrorOr<EntradaAndSalidaResultList>>;
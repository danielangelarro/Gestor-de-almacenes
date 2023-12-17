using ErrorOr;
using GestorDeAlmacenes.Application.DTO.Salidas;
using MediatR;

namespace GestorDeAlmacenes.Application.Salidas.Query.GetAllSalidas;

public record GetAllSalidasQuery() : IRequest<ErrorOr<SalidaResultList>>;

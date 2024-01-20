using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.EntradaAndSalidas;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;
using ErrorOr;
using GestorDeAlmacenes.Domain.Entities;

namespace GestorDeAlmacenes.Application.EntradaAndSalidas.Query.GetEntradaAndSalidaById;

public class GetEntradaAndSalidaByIdQueryHandler : IRequestHandler<GetAllEntradaAndSalidasQuery, ErrorOr<EntradaAndSalidaResultList>>
{
    private readonly IMovimientoRepository _movimientoRepository;

    public GetEntradaAndSalidaByIdQueryHandler(IMovimientoRepository movimientoRepository)
    {
        _movimientoRepository = movimientoRepository;
    }

    public async Task<ErrorOr<EntradaAndSalidaResultList>> Handle(GetAllEntradaAndSalidasQuery query, CancellationToken cancellationToken)
    {
        return new EntradaAndSalidaResultList(await _movimientoRepository.GetAllAsync());
    }
}
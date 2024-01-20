using ErrorOr;
using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Salidas;
using MediatR;

namespace GestorDeAlmacenes.Application.Salidas.Query.GetAllSalidas;

public class GetAllSalidasQueryHandler : IRequestHandler<GetAllSalidasQuery, ErrorOr<SalidaResultList>>
{
    private readonly IMovimientoRepository _repository;

    public GetAllSalidasQueryHandler(IMovimientoRepository salidaoRepository)
    {
        _repository = salidaoRepository;
    }

    public async Task<ErrorOr<SalidaResultList>> Handle(GetAllSalidasQuery query, CancellationToken cancellationToken)
    {
        return new SalidaResultList(await _repository.GetAllSalidasAsync());
    }
}
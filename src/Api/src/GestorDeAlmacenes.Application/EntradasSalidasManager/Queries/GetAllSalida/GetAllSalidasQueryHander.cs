using ErrorOr;
using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Salidas;
using MediatR;

namespace GestorDeAlmacenes.Application.Salidas.Query.GetAllSalidas;

public class GetAllSalidasQueryHandler : IRequestHandler<GetAllSalidasQuery, ErrorOr<SalidaResultList>>
{
    private readonly ISalidaRepository _repository;

    public GetAllSalidasQueryHandler(ISalidaRepository salidaoRepository)
    {
        _repository = salidaoRepository;
    }

    public async Task<ErrorOr<SalidaResultList>> Handle(GetAllSalidasQuery query, CancellationToken cancellationToken)
    {
        return new SalidaResultList(await _repository.GetAllSalidasAsync());
    }
}
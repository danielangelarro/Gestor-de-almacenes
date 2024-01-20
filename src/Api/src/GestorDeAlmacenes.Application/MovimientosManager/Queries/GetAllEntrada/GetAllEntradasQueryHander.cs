using ErrorOr;
using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Entradas;
using MediatR;

namespace GestorDeAlmacenes.Application.Entradas.Query.GetAllEntradas;

public class GetAllEntradasQueryHandler : IRequestHandler<GetAllEntradasQuery, ErrorOr<EntradaResultList>>
{
    private readonly IMovimientoRepository _repository;

    public GetAllEntradasQueryHandler(IMovimientoRepository entradaoRepository)
    {
        _repository = entradaoRepository;
    }

    public async Task<ErrorOr<EntradaResultList>> Handle(GetAllEntradasQuery query, CancellationToken cancellationToken)
    {
        return new EntradaResultList(await _repository.GetAllEntradasAsync());
    }
}
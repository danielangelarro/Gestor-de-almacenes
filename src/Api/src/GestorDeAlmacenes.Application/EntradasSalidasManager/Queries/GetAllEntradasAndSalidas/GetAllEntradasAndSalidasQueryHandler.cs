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
    private readonly IEntradaRepository _entradaRepository;
    private readonly ISalidaRepository _salidaRepository;

    public GetEntradaAndSalidaByIdQueryHandler(IEntradaRepository entradaRepository, ISalidaRepository salidaRepository)
    {
        _entradaRepository = entradaRepository;
        _salidaRepository = salidaRepository;
    }

    public async Task<ErrorOr<EntradaAndSalidaResultList>> Handle(GetAllEntradaAndSalidasQuery query, CancellationToken cancellationToken)
    {
        ICollection<ITransaction> entradas = (ICollection<ITransaction>)_entradaRepository.GetAllEntradasAsync();
        ICollection<ITransaction> salidas = (ICollection<ITransaction>)_entradaRepository.GetAllEntradasAsync();
        ICollection<ITransaction> search = (ICollection<ITransaction>)entradas.Concat(salidas);

        //TODO - Ordenar Arreglo Search por fecha

        return new EntradaAndSalidaResultList(search);
    }
}
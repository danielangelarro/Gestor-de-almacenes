using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Entradas;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;
using ErrorOr;
using GestorDeAlmacenes.Domain.Entities;
using GestorDeAlmacenes.Application.Common.Interfaces.Repository;

namespace GestorDeAlmacenes.Application.Entradas.Query.GetEntradaById;

public class GetEntradaByIdQueryHandler : IRequestHandler<GetEntradaByIdQuery, ErrorOr<EntradaResult>>
{
    private readonly IMovimientoRepository _repository;

    public GetEntradaByIdQueryHandler(IMovimientoRepository entradaRepository)
    {
        _repository = entradaRepository;
    }

    public async Task<ErrorOr<EntradaResult>> Handle(GetEntradaByIdQuery query, CancellationToken cancellationToken)
    {
        if (await _repository.GetEntradaByIdAsync(query.Id) is not Movimientos entrada)
        {
            return Errors.Entrada.NotFound;
        }

        return new EntradaResult(entrada);
    }
}
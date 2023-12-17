using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Entradas;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Entradas.Query.GetEntradaById;

public class GetEntradaByIdQueryHandler : IRequestHandler<GetEntradaByIdQuery, ErrorOr<EntradaResult>>
{
    private readonly IEntradaRepository _repository;

    public GetEntradaByIdQueryHandler(IEntradaRepository entradaRepository)
    {
        _repository = entradaRepository;
    }

    public async Task<ErrorOr<EntradaResult>> Handle(GetEntradaByIdQuery query, CancellationToken cancellationToken)
    {
        if (await _repository.GetEntradaByIdAsync(query.Id) is not Entrada entrada)
        {
            return Errors.Entrada.NotFound;
        }

        Entrada? entradao = await _repository.GetEntradaByIdAsync(query.Id);

        return new EntradaResult(entradao);
    }
}
using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Mermas;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Mermas.Query.GetMermaById;

public class GetMermaByIdQueryHandler : IRequestHandler<GetMermaByIdQuery, ErrorOr<MermaResult>>
{
    private readonly IMovimientoRepository _repository;

    public GetMermaByIdQueryHandler(IMovimientoRepository mermaRepository)
    {
        _repository = mermaRepository;
    }

    public async Task<ErrorOr<MermaResult>> Handle(GetMermaByIdQuery query, CancellationToken cancellationToken)
    {
        if (await _repository.GetMermaByIdAsync(query.Id) is not Movimientos merma)
        {
            return Errors.Merma.NotFound;
        }

        Movimientos mermao = await _repository.GetMermaByIdAsync(query.Id);

        return new MermaResult(mermao);
    }
}
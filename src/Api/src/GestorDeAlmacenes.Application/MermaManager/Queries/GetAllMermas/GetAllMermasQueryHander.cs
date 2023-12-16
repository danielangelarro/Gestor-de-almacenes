using ErrorOr;
using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Mermas;
using MediatR;

namespace GestorDeAlmacenes.Application.Mermas.Query.GetAllMermas;

public class GetAllMermasQueryHandler : IRequestHandler<GetAllMermasQuery, ErrorOr<MermaResultList>>
{
    private readonly IMermaRepository _repository;

    public GetAllMermasQueryHandler(IMermaRepository mermaoRepository)
    {
        _repository = mermaoRepository;
    }

    public async Task<ErrorOr<MermaResultList>> Handle(GetAllMermasQuery query, CancellationToken cancellationToken)
    {
        return new MermaResultList(await _repository.GetAllMermasAsync());
    }
}
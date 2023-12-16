using ErrorOr;
using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Racks;
using MediatR;

namespace GestorDeAlmacenes.Application.Racks.Query.GetAllRacks;

public class GetAllRacksQueryHandler : IRequestHandler<GetAllRacksQuery, ErrorOr<RackResultList>>
{
    private readonly IRackRepository _repository;

    public GetAllRacksQueryHandler(IRackRepository rackoRepository)
    {
        _repository = rackoRepository;
    }

    public async Task<ErrorOr<RackResultList>> Handle(GetAllRacksQuery query, CancellationToken cancellationToken)
    {
        return new RackResultList(await _repository.GetAllRacksAsync());
    }
}
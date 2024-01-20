using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Casilleros;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Casilleros.Query.GetCasilleroWait;

public class GetCasilleroByRackIdQueryHandler : IRequestHandler<GetCasilleroWaitQuery, ErrorOr<CasilleroResult>>
{
    private readonly ICasilleroRepository _repository;
    private readonly IRackRepository _rackRepository;

    public GetCasilleroByRackIdQueryHandler(ICasilleroRepository casilleroRepository, IRackRepository rackRepository)
    {
        _repository = casilleroRepository;
        _rackRepository = rackRepository;
    }

    public async Task<ErrorOr<CasilleroResult>> Handle(GetCasilleroWaitQuery query, CancellationToken cancellationToken)
    {
        var rack = await _rackRepository.GetWaitRacksAsync();
        var casilleros = await _repository.GetAllCasillerosByRackIdAsync(rack.ID_Rack);

        return new CasilleroResult(casilleros.FirstOrDefault());
    }
}
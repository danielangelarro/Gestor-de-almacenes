using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Casilleros;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Casilleros.Query.GetCasilleroByRackId;

public class GetCasilleroByRackIdQueryHandler : IRequestHandler<GetCasilleroByIdRackQuery, ErrorOr<CasilleroResultList>>
{
    private readonly ICasilleroRepository _repository;

    public GetCasilleroByRackIdQueryHandler(ICasilleroRepository casilleroRepository)
    {
        _repository = casilleroRepository;
    }

    public async Task<ErrorOr<CasilleroResultList>> Handle(GetCasilleroByIdRackQuery query, CancellationToken cancellationToken)
    {
        return new CasilleroResultList(await _repository.GetAllCasillerosByRackIdAsync(query.ID_Rack));
    }
}
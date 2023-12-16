using ErrorOr;
using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Casilleros;
using MediatR;

namespace GestorDeAlmacenes.Application.Casilleros.Query.GetAllCasilleros;

public class GetAllCasillerosByIdQueryHandler : IRequestHandler<GetAllCasillerosByIdQuery, ErrorOr<CasilleroResultList>>
{
    private readonly ICasilleroRepository _repository;

    public GetAllCasillerosByIdQueryHandler(ICasilleroRepository casillerooRepository)
    {
        _repository = casillerooRepository;
    }

    public async Task<ErrorOr<CasilleroResultList>> Handle(GetAllCasillerosByIdQuery query, CancellationToken cancellationToken)
    {
        return new CasilleroResultList(await _repository.GetAllCasillerosByIdAsync(query.Guids));
    }
}
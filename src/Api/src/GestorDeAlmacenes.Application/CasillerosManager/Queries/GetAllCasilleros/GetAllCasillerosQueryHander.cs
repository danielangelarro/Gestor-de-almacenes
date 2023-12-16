using ErrorOr;
using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Casilleros;
using MediatR;

namespace GestorDeAlmacenes.Application.Casilleros.Query.GetAllCasilleros;

public class GetAllCasillerosQueryHandler : IRequestHandler<GetAllCasillerosQuery, ErrorOr<CasilleroResultList>>
{
    private readonly ICasilleroRepository _repository;

    public GetAllCasillerosQueryHandler(ICasilleroRepository casillerooRepository)
    {
        _repository = casillerooRepository;
    }

    public async Task<ErrorOr<CasilleroResultList>> Handle(GetAllCasillerosQuery query, CancellationToken cancellationToken)
    {
        return new CasilleroResultList(await _repository.GetAllCasillerosAsync());
    }
}
using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Casilleros;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Casilleros.Query.GetCasilleroById;

public class GetCasilleroByIdQueryHandler : IRequestHandler<GetCasilleroByIdQuery, ErrorOr<CasilleroResult>>
{
    private readonly ICasilleroRepository _repository;

    public GetCasilleroByIdQueryHandler(ICasilleroRepository casilleroRepository)
    {
        _repository = casilleroRepository;
    }

    public async Task<ErrorOr<CasilleroResult>> Handle(GetCasilleroByIdQuery query, CancellationToken cancellationToken)
    {
        if (await _repository.GetCasilleroByIdAsync(query.Id) is not Casillero casillero)
        {
            return Errors.Casillero.NotFound;
        }

        Casillero? casilleroo = await _repository.GetCasilleroByIdAsync(query.Id);

        return new CasilleroResult(casilleroo);
    }
}
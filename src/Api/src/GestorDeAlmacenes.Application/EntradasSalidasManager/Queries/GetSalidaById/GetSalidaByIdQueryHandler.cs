using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Salidas;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Salidas.Query.GetSalidaById;

public class GetSalidaByIdQueryHandler : IRequestHandler<GetSalidaByIdQuery, ErrorOr<SalidaResult>>
{
    private readonly ISalidaRepository _repository;

    public GetSalidaByIdQueryHandler(ISalidaRepository salidaRepository)
    {
        _repository = salidaRepository;
    }

    public async Task<ErrorOr<SalidaResult>> Handle(GetSalidaByIdQuery query, CancellationToken cancellationToken)
    {
        if (await _repository.GetSalidaByIdAsync(query.Id) is not Salida salida)
        {
            return Errors.Salida.NotFound;
        }

        Salida? salidao = await _repository.GetSalidaByIdAsync(query.Id);

        return new SalidaResult(salidao);
    }
}
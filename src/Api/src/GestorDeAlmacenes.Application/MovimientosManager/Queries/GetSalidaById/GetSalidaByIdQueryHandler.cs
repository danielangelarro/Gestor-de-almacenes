using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Salidas;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Salidas.Query.GetSalidaById;

public class GetSalidaByIdQueryHandler : IRequestHandler<GetSalidaByIdQuery, ErrorOr<SalidaResult>>
{
    private readonly IMovimientoRepository _repository;
    private readonly IUbicacionSalidaRepository _ubicacionSalidaRepository;

    public GetSalidaByIdQueryHandler(IMovimientoRepository salidaRepository, IUbicacionSalidaRepository ubicacionSalidaRepository)
    {
        _repository = salidaRepository;
        _ubicacionSalidaRepository = ubicacionSalidaRepository;
    }

    public async Task<ErrorOr<SalidaResult>> Handle(GetSalidaByIdQuery query, CancellationToken cancellationToken)
    {
        if (await _repository.GetSalidaByIdAsync(query.Id) is not Movimientos salida)
        {
            return Errors.Salida.NotFound;
        }

        ICollection<Ubicacion_Salida> ubicaciones = await _ubicacionSalidaRepository.GetAllUbicacionesSalidasBySalidaAsync(salida.ID_Movimiento);

        return new SalidaResult(salida, ubicaciones);
    }
}
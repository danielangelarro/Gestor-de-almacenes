using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Casilleros;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Casilleros.Query.GetCasilleroById;

public class GetCasilleroByIdQueryHandler : IRequestHandler<GetCasilleroByIdQuery, ErrorOr<CasilleroResultInfo>>
{
    private readonly ICasilleroRepository _repository;
    private readonly IUbicacionRepository _ubicacionRepository;
    private readonly IProductoRepository _productoRepository;

    public GetCasilleroByIdQueryHandler(ICasilleroRepository casilleroRepository, IUbicacionRepository ubicacionRepository, IProductoRepository productoRepository)
    {
        _repository = casilleroRepository;
        _ubicacionRepository = ubicacionRepository;
        _productoRepository = productoRepository;
    }

    public async Task<ErrorOr<CasilleroResultInfo>> Handle(GetCasilleroByIdQuery query, CancellationToken cancellationToken)
    {
        if (await _repository.GetCasilleroByIdAsync(query.Id) is not Casillero casillero)
        {
            return Errors.Casillero.NotFound;
        }

        Console.WriteLine("casilleros OK");
        IEnumerable<Ubicacion> ubicaciones = await _ubicacionRepository.GetAllUbicacionesByCasilleroAsync(query.Id);
        Console.WriteLine("ubicaciones OK");
        List<Producto> productos = new List<Producto>();
        float capacidad_Peso = 0, capacidad_Volumen = 0;

        foreach (var ubicacion in ubicaciones)
        {
            Producto producto = await _productoRepository.GetProductoByIdAsync(ubicacion.ID_Producto);
            
            productos.Add(producto);

            capacidad_Peso += producto.Peso;
            capacidad_Volumen += producto.Ancho * producto.Alto * producto.Largo;
        }

        return new CasilleroResultInfo(
            casillero, 
            productos,
            capacidad_Peso,
            capacidad_Volumen
        );
    }
}
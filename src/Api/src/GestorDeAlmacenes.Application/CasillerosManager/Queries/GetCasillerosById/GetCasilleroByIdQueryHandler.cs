using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Casilleros;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;
using ErrorOr;
using GestorDeAlmacenes.Application.DTO.Product;

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

        IEnumerable<Ubicacion> ubicaciones = await _ubicacionRepository.GetAllUbicacionesByCasilleroAsync(query.Id);
        List<ResultUbicacion> productos = new List<ResultUbicacion>();
        float capacidad_Peso = 0, capacidad_Volumen = 0;

        foreach (var ubicacion in ubicaciones)
        {
            Producto producto = await _productoRepository.GetProductoByIdAsync(ubicacion.ID_Producto);
            
            productos.Add(new ResultUbicacion(
                ID_Ubicacion: ubicacion.ID_Ubicacion,
                ID_Producto: ubicacion.ID_Producto,
                ID_Casillero: ubicacion.ID_Casillero,
                Nombre: producto.Nombre,
                Tipo: producto.Tipo,
                Alto: producto.Alto,
                Largo: producto.Largo,
                Ancho: producto.Ancho,
                Unidad_Dimensions: producto.Unidad_Dimensiones,
                Peso: producto.Peso,
                Cantidad: ubicacion.Cantidad,
                Fecha_Llegada: ubicacion.Fecha_Llegada,
                Fecha_Caducidad: ubicacion.Fecha_Caducidad,
                Confirmar_Guardado: ubicacion.Confirmar_Guardado
            ));

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
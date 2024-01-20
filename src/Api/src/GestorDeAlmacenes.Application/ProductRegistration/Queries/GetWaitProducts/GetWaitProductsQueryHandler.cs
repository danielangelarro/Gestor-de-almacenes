using ErrorOr;
using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Gallery;
using GestorDeAlmacenes.Application.DTO.Product;
using GestorDeAlmacenes.Application.Entities;
using MediatR;

namespace GestorDeAlmacenes.Application.Product.Query.GetWaitProducts;

public class GetWaitProductsQueryHandler : IRequestHandler<GetWaitProductsQuery, ErrorOr<ProductResultUbicacionList>>
{
    private readonly IProductoRepository _repository;
    private readonly IUbicacionRepository _ubicacionRepository;
    private readonly ICasilleroRepository _casilleroRepository;
    private readonly IRackRepository _rackRepository;

    public GetWaitProductsQueryHandler(
        IProductoRepository productoRepository, 
        IUbicacionRepository ubicacionRepository, 
        ICasilleroRepository casilleroRepository, 
        IRackRepository rackRepository)
    {
        _repository = productoRepository;
        _ubicacionRepository = ubicacionRepository;
        _casilleroRepository = casilleroRepository;
        _rackRepository = rackRepository;
    }

    public async Task<ErrorOr<ProductResultUbicacionList>> Handle(GetWaitProductsQuery query, CancellationToken cancellationToken)
    {
        var rack = await _rackRepository.GetWaitRacksAsync();
        var casilleros = await _casilleroRepository.GetAllCasillerosByRackIdAsync(rack.ID_Rack);
        var casillero = casilleros.FirstOrDefault();

        var ubicaciones = await _ubicacionRepository.GetAllUbicacionesByCasilleroAsync(casillero.ID_Casillero);

        List<ResultUbicacion> ProductResultUbicacion = new List<ResultUbicacion>();

        foreach (var item in ubicaciones)
        {
            var producto = await _repository.GetProductoByIdAsync(item.ID_Producto);

            ProductResultUbicacion.Add(new ResultUbicacion(
                ID_Ubicacion: item.ID_Ubicacion,
                ID_Producto: item.ID_Producto,
                ID_Casillero: item.ID_Casillero,
                Nombre: producto.Nombre,
                Tipo: producto.Tipo,
                Alto: producto.Alto,
                Largo: producto.Largo,
                Ancho: producto.Ancho,
                Unidad_Dimensions: producto.Unidad_Dimensiones,
                Peso: producto.Peso,
                Cantidad: item.Cantidad,
                Fecha_Llegada: item.Fecha_Llegada,
                Fecha_Caducidad: item.Fecha_Caducidad,
                Confirmar_Guardado: item.Confirmar_Guardado
            ));
        }

        return new ProductResultUbicacionList(ProductResultUbicacion);
    }
}
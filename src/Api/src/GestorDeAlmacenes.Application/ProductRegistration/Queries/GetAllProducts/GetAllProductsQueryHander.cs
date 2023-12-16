using ErrorOr;
using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Gallery;
using GestorDeAlmacenes.Application.DTO.Product;
using MediatR;

namespace GestorDeAlmacenes.Application.Product.Query.GetAllProducts;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, ErrorOr<ProductResultList>>
{
    private readonly IProductoRepository _repository;

    public GetAllProductsQueryHandler(IProductoRepository productoRepository)
    {
        _repository = productoRepository;
    }

    public async Task<ErrorOr<ProductResultList>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
    {
        return new ProductResultList(await _repository.GetAllProductosAsync());
    }
}
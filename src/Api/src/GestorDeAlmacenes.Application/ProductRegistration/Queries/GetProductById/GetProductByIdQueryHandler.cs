using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Domain.Common.Errors;
using GestorDeAlmacenes.Application.DTO.Product;
using GestorDeAlmacenes.Application.Entities;
using ErrorOr;
using MediatR;

namespace GestorDeAlmacenes.Application.Product.Query.GetProductById;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ErrorOr<ProductResult>>
{
    private readonly IProductoRepository _repository;

    public GetProductByIdQueryHandler(IProductoRepository productoRepository)
    {
        _repository = productoRepository;
    }

    public async Task<ErrorOr<ProductResult>> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        if (await _repository.GetProductoByIdAsync(query.Id) is not Producto product)
        {
            return Errors.Producto.NotFound;
        }

        Producto? producto = await _repository.GetProductoByIdAsync(query.Id);

        return new ProductResult(producto);
    }
}
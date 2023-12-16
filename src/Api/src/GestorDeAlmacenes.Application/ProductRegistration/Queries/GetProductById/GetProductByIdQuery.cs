using ErrorOr;
using GestorDeAlmacenes.Application.DTO.Product;
using MediatR;

namespace GestorDeAlmacenes.Application.Product.Query.GetProductById;

public record GetProductByIdQuery(
    Guid Id
) : IRequest<ErrorOr<ProductResult>>;
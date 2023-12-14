using ErrorOr;
using GestorDeAlmacenes.Application.DTO.Gallery;
using GestorDeAlmacenes.Application.DTO.Product;
using MediatR;

namespace GestorDeAlmacenes.Application.Product.Query.GetAllProducts;

public record GetAllProductsQuery() : IRequest<ErrorOr<ProductResultList>>;

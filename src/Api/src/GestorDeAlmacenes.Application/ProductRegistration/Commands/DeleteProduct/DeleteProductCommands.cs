using GestorDeAlmacenes.Application.DTO.Product;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Product.Commands.Delete;

public record DeleteProductCommands(
   Guid Id
) : IRequest<ErrorOr<ProductResult>>;


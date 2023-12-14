using System.Net.Http.Headers;
using GestorDeAlmacenes.Application.Common.Interfaces;
using GestorDeAlmacenes.Application.DTO.Product;
using GestorDeAlmacenes.Application.Entities;
using GestorDeAlmacenes.Domain.Common.Errors;
using MediatR;
using ErrorOr;

namespace GestorDeAlmacenes.Application.Product.Commands.Delete;

public class DeleteProductCommandsHandler : IRequestHandler<DeleteProductCommands, ErrorOr<ProductResult>>
{
   private readonly IProductoRepository _productRepository;

   public DeleteProductCommandsHandler(IProductoRepository productRepository)
   {
       _productRepository = productRepository;
   }

   public async Task<ErrorOr<ProductResult>> Handle(DeleteProductCommands command, CancellationToken cancellationToken)
   {
        if (await _productRepository.GetProductoByIdAsync(command.Id) is not Producto product)
        {
            return Errors.Producto.NotFound;
        }

       await _productRepository.DeleteProductoAsync(product);
       
       return new ProductResult(product);
   }
}
